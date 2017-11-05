using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Productvendor
    {
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal? LastReceiptCost { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public int? OnOrderQty { get; set; }
        public string UnitMeasureCode { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Product Product { get; set; }
        public Vendor Vendor { get; set; }
    }
}
