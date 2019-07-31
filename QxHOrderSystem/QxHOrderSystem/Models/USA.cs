using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QxHOrderSystem.Models
{
    public class USA
    {
        [Key]
        public int ShowItemId { get; set; }
        public int itemId { get; set; }
        public int planSeqId { get; set; }
        public string itemDescription { get; set; }
        public int orderQuantity { get; set; }
        public int orderSldTdy { get; set; }
        public int plannedMinutesQty { get; set; }
        public int actualMinutesQty { get; set; }
        public int networkId { get; set; }
        public int companyId { get; set; }
        public int avaiForSaleQty { get; set; }
        public DateTime showDate { get; set; }
        public string showCd { get; set; }
        [NotMapped]
        public int InputQty { get; set; } 
    }
}
