using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.N1QL;
using Microsoft.AspNetCore.Mvc;
using QxHDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public static int NetworkId;

        public static int CompanyId;

        public static int CardId;


        private readonly List<SelectListItem> _countries = new List<SelectListItem>
        {
            new SelectListItem {Value = "0", Text = "USA"},
            new SelectListItem {Value = "1", Text = "EUR"},
            new SelectListItem {Value = "2", Text = "JPN"}
        };

        private readonly List<SelectListItem> _cards = new List<SelectListItem>
        {
            new SelectListItem {Value = "0", Text = "A"},
            new SelectListItem {Value = "1", Text = "B"},
            new SelectListItem {Value = "2", Text = "C"},
            new SelectListItem {Value = "3", Text = "D"},
            new SelectListItem {Value = "4", Text = "E"},
            new SelectListItem {Value = "5", Text = "F"},
            new SelectListItem {Value = "6", Text = "G"},
            new SelectListItem {Value = "7", Text = "H"},
            new SelectListItem {Value = "8", Text = "I"},
            new SelectListItem {Value = "9", Text = "J"},
            new SelectListItem {Value = "10", Text = "K"},
            new SelectListItem {Value = "11", Text = "L"},
            new SelectListItem {Value = "12", Text = "M"},
            new SelectListItem {Value = "13", Text = "N"},
            new SelectListItem {Value = "14", Text = "O"},
            new SelectListItem {Value = "15", Text = "P"},
            new SelectListItem {Value = "16", Text = "Q"},
            new SelectListItem {Value = "17", Text = "R"},
            new SelectListItem {Value = "18", Text = "S"},
            new SelectListItem {Value = "19", Text = "T"},
            new SelectListItem {Value = "20", Text = "U"},
            new SelectListItem {Value = "21", Text = "V"},
            new SelectListItem {Value = "22", Text = "W"},
            new SelectListItem {Value = "23", Text = "X"}            
        };

        private readonly List<SelectListItem> _networks = new List<SelectListItem>
        {
            new SelectListItem {Value = "0", Text = "Global"},
            new SelectListItem {Value = "1", Text = "HSN"},
            new SelectListItem {Value = "2", Text = "HSN.com"},
            new SelectListItem {Value = "3", Text = "HSN2"}
        };

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
            var bucket = _bucketProvider.GetBucket(countryName);
            var n1ql = @"SELECT g.*, META(g).id
                        FROM `" + countryName + "` g " +
                        "WHERE g.companyId = " + model.SelectedCountry.CountryId + " " +
                        "AND g.showCd = '" + model.SelectedCard.CardLetter + "' " +
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

            model.SelectedCard.CardLetter = GetTime(DateTime.Now, model);

            //NetworkId = model.SelectedNetworkId;
            //CompanyId = model.SelectedCountryId;
            //CardId = model.SelectedCardId;

            string countryName = FindCountryName(model.SelectedCountry.CountryId);
            var bucket = _bucketProvider.GetBucket(countryName);
            var n1ql = @"SELECT g.*, META(g).id
                        FROM `" + countryName + "` g " +
                        "WHERE g.companyId = " + model.SelectedCountry.CountryId + " " +
                        "AND g.showCd = '" + GetTime(DateTime.Now, model) + "' " +
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

            //NetworkId = model.SelectedNetworkId;
            //CompanyId = model.SelectedCountryId;
            //CardId = model.SelectedCardId;

            string countryName = FindCountryName(model.SelectedCountry.CountryId);
            var bucket = _bucketProvider.GetBucket(countryName);
            var n1ql = @"SELECT g.*, META(g).id
                        FROM `" + countryName + "` g " +
                        "WHERE g.companyId = " + model.SelectedCountry.CountryId + " " +
                        "AND g.showCd = '" + model.SelectedCard.CardLetter + "' " +
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

            if (countryId == 0)
                countryName = "MerchUSA";
            else if (countryId == 1)
                countryName = "MerchEUR";
            else
                countryName = "MerchJPN";

            return countryName;
        }              

        //Return ShowCard to bucket query for DateTime.Now
        private string GetTime(DateTime date, MerchandiseViewModel model)
        {            
            int hour = date.Hour;
            switch(hour)
            {
                case 0:
                    model.SelectedCard.CardLetter = "A";
                    return "A";
                case 1:
                    model.SelectedCard.CardLetter = "B";
                    return "B";                    
                case 2:
                    model.SelectedCard.CardLetter = "C";
                    return "C";                    
                case 3:
                    model.SelectedCard.CardLetter = "D";
                    return "D";                    
                case 4:
                    model.SelectedCard.CardLetter = "E";
                    return "E";                    
                case 5:
                    model.SelectedCard.CardLetter = "F";
                    return "F";                   
                case 6:
                    model.SelectedCard.CardLetter = "G";
                    return "G";                    
                case 7:
                    model.SelectedCard.CardLetter = "H";
                    return "H";                    
                case 8:
                    model.SelectedCard.CardLetter = "I";
                    return "I";                    
                case 9:
                    model.SelectedCard.CardLetter = "J";
                    return "J";                    
                case 10:
                    model.SelectedCard.CardLetter = "K";
                    return "K";                    
                case 11:
                    model.SelectedCard.CardLetter = "L";
                    return "L";                    
                case 12:
                    model.SelectedCard.CardLetter = "M";
                    return "M";                    
                case 13:
                    model.SelectedCard.CardLetter = "N";
                    return "N";                    
                case 14:
                    model.SelectedCard.CardLetter = "O";
                    return "O";                    
                case 15:
                    model.SelectedCard.CardLetter = "P";
                    return "P";                    
                case 16:
                    model.SelectedCard.CardLetter = "Q";
                    return "Q";                    
                case 17:
                    model.SelectedCard.CardLetter = "R";
                    return "R";                    
                case 18:
                    model.SelectedCard.CardLetter = "S";
                    return "S";                    
                case 19:
                    model.SelectedCard.CardLetter = "T";
                    return "T";                    
                case 20:
                    model.SelectedCard.CardLetter = "U";
                    return "U";                    
                case 21:
                    model.SelectedCard.CardLetter = "V";
                    return "V";                    
                case 22:
                    model.SelectedCard.CardLetter = "W";
                    return "W";                    
                case 23:
                    model.SelectedCard.CardLetter = "X";
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
