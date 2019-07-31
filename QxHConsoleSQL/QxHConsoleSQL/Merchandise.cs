namespace QxHConsoleSQL
{
    class Merchandise
    {        
        public int PlanSeqId { get; set; }
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public int OrderQuantity { get; set; }
        public int OrderSldTdy { get; set; }
        public int PlannedMinutesQty { get; set; }
        public int ActualMinutesQty { get; set; }
        public int NetworkId { get; set; }
        public int CompanyId { get; set; }
        public int AvaiForSaleQty { get; set; }
        public string ShowDate { get; set; }
        public string ShowCd { get; set; }
    }
}
