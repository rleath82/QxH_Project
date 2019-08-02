using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.N1QL;
using Microsoft.AspNetCore.Mvc;
using QxHDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace QxHDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBucketProvider _bucketProvider;
        
        public HomeController(IBucketProvider bucketProvider)
        {
            _bucketProvider = bucketProvider;            
        }            

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Saving the state of dropdowns for auto refresh
        public static int NetworkId;

        public static int CompanyId;

        public static int CardId;


        private readonly List<SelectListItem> _countries = new List<SelectListItem>
        {
            new SelectListItem {Value = "0", Text = "QVC - USA"},
            new SelectListItem {Value = "3", Text = "HSN - USA"},
            new SelectListItem {Value = "1", Text = "QVC - EUR"},
            new SelectListItem {Value = "2", Text = "QVC - JPN"}
        };

        private readonly List<SelectListItem> _cards = new List<SelectListItem>
        {
            new SelectListItem {Value = "0", Text = "A - 12 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "1", Text = "B - 1 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "2", Text = "C - 2 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "3", Text = "D - 3 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "4", Text = "E - 4 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "5", Text = "F - 5 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "6", Text = "G - 6 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "7", Text = "H - 7 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "8", Text = "I - 8 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "9", Text = "J - 9 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "10", Text = "K - 10 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "11", Text = "L - 11 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "12", Text = "M - 12 am " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "13", Text = "N - 1 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "14", Text = "O - 2 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "15", Text = "P - 3 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "16", Text = "Q - 4 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "17", Text = "R - 5 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "18", Text = "S - 6 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "19", Text = "T - 7 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "20", Text = "U - 8 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "21", Text = "V - 9 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "22", Text = "W - 10 pm " + DateTime.Now.ToString("MM/dd/y")},
            new SelectListItem {Value = "23", Text = "X - 11 pm " + DateTime.Now.ToString("MM/dd/y")}            
        };

        private readonly List<SelectListItem> _networks = new List<SelectListItem>
        {
            new SelectListItem {Value = "0", Text = "Global"},
            new SelectListItem {Value = "1", Text = "TV"},
            new SelectListItem {Value = "2", Text = "Digital"}            
        };

        [Authorize(Roles = "admin")]

        public IActionResult SelectDDView()
        {
            var model = new MerchandiseViewModel { countries = _countries };
            GetMerchandise(model);
            return View(model);
        }

        //Upon user selected options, display appropriate data.
        public IActionResult GetState(MerchandiseViewModel model)
        {
            model.countries = _countries;
            model.cards = _cards;
            model.networks = _networks;
            model.SelectedCountry = (from c in model.countries
                                     where c.Value == model.SelectedCountryId.ToString()
                                     select new Country
                                     {
                                         CountryId = int.Parse(c.Value),
                                         CountryName = c.Text
                                     }).FirstOrDefault();

            model.SelectedCard = (from d in model.cards
                                  where d.Value == model.SelectedCardId.ToString()
                                  select new Card
                                  {
                                      CardId = int.Parse(d.Value),
                                      CardLetter = d.Text
                                  }).FirstOrDefault();

            model.SelectedNetwork = (from n in model.networks
                                     where n.Value == model.SelectedNetworkId.ToString()
                                     select new Network
                                     {
                                         NetworkId = int.Parse(n.Value),
                                         NetworkName = n.Text
                                     }).FirstOrDefault();

            NetworkId = model.SelectedNetworkId;
            CompanyId = model.SelectedCountryId;
            CardId = model.SelectedCardId;

            string countryName = FindCountryName(model.SelectedCountry.CountryId);
            string cardLetter = GetCard(model.SelectedCard.CardId);
            int countryCode = FindCountryCode(model.SelectedCountry.CountryId);
            var bucket = _bucketProvider.GetBucket(countryName);
            var n1ql = @"SELECT g.*, META(g).id
                        FROM `" + countryName + "` g " +
                        "WHERE g.companyId = " + countryCode + " " +
                        "AND g.showCd = '" + cardLetter + "' " +
                        "AND g.networkId = " + model.SelectedNetwork.NetworkId + " " +
                        "LIMIT 20;";

            var query = QueryRequest.Create(n1ql);
            var results = bucket.Query<Merchandise>(query);
            try
            {
                model.merchandise = results.Rows;
            }
            catch (global::System.Exception)
            {
                throw;
            }
            return View(model);            
        }

        //On page load, display DateTime.Now ShowCard
        public IActionResult GetMerchandise(MerchandiseViewModel model)
        {
            model.countries = _countries;
            model.cards = _cards;
            model.networks = _networks;
                       

            model.SelectedCountry = (from c in model.countries
                                     where c.Value == model.SelectedCountryId.ToString()
                                     select new Country
                                     {
                                         CountryId = int.Parse(c.Value),
                                         CountryName = c.Text
                                     }).FirstOrDefault();

            model.SelectedCard = (from d in model.cards
                                  where d.Value == model.SelectedCardId.ToString()
                                  select new Card
                                  {
                                      CardId = int.Parse(d.Value),
                                      CardLetter = d.Text
                                  }).FirstOrDefault();

            model.SelectedNetwork = (from n in model.networks
                                     where n.Value == model.SelectedNetworkId.ToString()
                                     select new Network
                                     {
                                         NetworkId = int.Parse(n.Value),
                                         NetworkName = n.Text
                                     }).FirstOrDefault();            

            string cardLetter = GetCard(model.SelectedCard.CardId);
            string countryName = FindCountryName(model.SelectedCountry.CountryId);
            var bucket = _bucketProvider.GetBucket(countryName);
            var n1ql = @"SELECT g.*, META(g).id
                        FROM `" + countryName + "` g " +
                        "WHERE g.companyId = " + model.SelectedCountry.CountryId + " " +
                        "AND g.showCd = '" + cardLetter + "' " +
                        "AND g.networkId = " + model.SelectedNetwork.NetworkId + " " +
                        "LIMIT 20;";
            var query = QueryRequest.Create(n1ql);
            var results = bucket.Query<Merchandise>(query);
            try
            {
                model.merchandise = results.Rows;
            }
            catch (global::System.Exception)
            {
                throw;
            }
            return View(model);
        }

        public JsonResult RefreshTable(MerchandiseViewModel model)
        {
            model.countries = _countries;
            model.cards = _cards;
            model.networks = _networks;
            model.SelectedCountry = (from c in model.countries
                                     where c.Value == model.SelectedCountryId.ToString()
                                     select new Country
                                     {
                                         CountryId = int.Parse(c.Value),
                                         CountryName = c.Text
                                     }).FirstOrDefault();

            model.SelectedCard = (from d in model.cards
                                  where d.Value == model.SelectedCardId.ToString()
                                  select new Card
                                  {
                                      CardId = int.Parse(d.Value),
                                      CardLetter = d.Text
                                  }).FirstOrDefault();

            model.SelectedNetwork = (from n in model.networks
                                     where n.Value == model.SelectedNetworkId.ToString()
                                     select new Network
                                     {
                                         NetworkId = int.Parse(n.Value),
                                         NetworkName = n.Text
                                     }).FirstOrDefault();

            string cardLetter = GetCard(model.SelectedCard.CardId);
            string countryName = FindCountryName(model.SelectedCountry.CountryId);
            int countryCode = FindCountryCode(model.SelectedCountry.CountryId);
            var bucket = _bucketProvider.GetBucket(countryName);
            var n1ql = @"SELECT g.*, META(g).id
                        FROM `" + countryName + "` g " +
                        "WHERE g.companyId = " + countryCode + " " +
                        "AND g.showCd = '" + cardLetter + "' " +
                        "AND g.networkId = " + NetworkId + " " +
                        "LIMIT 20;";

            var query = QueryRequest.Create(n1ql);
            var results = bucket.Query<Merchandise>(query);
            try
            {
                model.merchandise = results.Rows;
            }
            catch (global::System.Exception)
            {
                throw;
            }
            return Json(model.merchandise);
        }

        //SelectList change
        [HttpPost]
        public IActionResult SelectDDView(MerchandiseViewModel model)
        {
            GetState(model);
            return View(model);
        }

        //Display current string for bucket name
        private string FindCountryName(int countryId)
        {
            string countryName;

            if (countryId == 0 || countryId == 3)
                countryName = "MerchUSA";
            else if (countryId == 1)
                countryName = "MerchEUR";
            else
                countryName = "MerchJPN";

            return countryName;
        }              

        //Temporary fix, should not include this in production
        private int FindCountryCode(int countryId)
        {
            if (countryId == 0 || countryId == 3)
                return 0;
            else if (countryId == 1)
                return 1;
            else
                return 2;
        }

        //Return ShowCard to bucket query for DateTime.Now
        private string GetTime(DateTime date, MerchandiseViewModel model)
        {            
            int hour = date.Hour;
            switch(hour)
            {
                case 0:                    
                    return "A";
                case 1:                    
                    return "B";                    
                case 2:                    
                    return "C";                    
                case 3:                    
                    return "D";                    
                case 4:                    
                    return "E";                    
                case 5:                    
                    return "F";                   
                case 6:
                    return "G";                    
                case 7:
                    return "H";                    
                case 8:
                    return "I";                    
                case 9:
                    return "J";                    
                case 10:
                    return "K";                    
                case 11:
                    return "L";                    
                case 12:
                    return "M";                    
                case 13:
                    return "N";                    
                case 14:
                    return "O";                    
                case 15:
                    return "P";                    
                case 16:
                    return "Q";                    
                case 17:
                    return "R";                    
                case 18:
                    return "S";                    
                case 19:
                    return "T";                    
                case 20:
                    return "U";                    
                case 21:
                    return "V";                    
                case 22:
                    return "W";                    
                case 23:
                    return "X";                    
                default:
                    break;
            }
            return "A";
        }      
        
        private string GetCard(int cardId)
        {
            //int cardId = model.SelectedCard.CardId;
            switch (cardId)
            {
                case 0:                    
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                case 8:
                    return "I";
                case 9:
                    return "J";
                case 10:
                    return "K";
                case 11:
                    return "L";
                case 12:
                    return "M";
                case 13:
                    return "N";
                case 14:
                    return "O";
                case 15:
                    return "P";
                case 16:
                    return "Q";
                case 17:
                    return "R";
                case 18:
                    return "S";
                case 19:
                    return "T";
                case 20:
                    return "U";
                case 21:
                    return "V";
                case 22:
                    return "W";
                case 23:
                    return "X";
                default:
                    break;
            }
            return "A";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }    
}
