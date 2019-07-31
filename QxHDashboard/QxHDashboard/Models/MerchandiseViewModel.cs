using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace QxHDashboard.Models
{
    //Created ViewModel for the countries, not sure how to link with the razor dropdown
    public class MerchandiseViewModel
    {
        public List<SelectListItem> countries { get; set; }
        public int SelectedCountryId { get; set; }
        public Country SelectedCountry { get; set; }

        public List<SelectListItem> cards { get; set; }
        public int SelectedCardId { get; set; }
        public Card SelectedCard { get; set; }

        public List<SelectListItem> networks { get; set; }
        public int SelectedNetworkId { get; set; }
        public Network SelectedNetwork { get; set; }

        public List<Merchandise> dateTime { get; set; }

        public List<Merchandise> merchandise { get; set; }
    }
}
