using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Vendorcontact
    {
        public int VendorId { get; set; }
        public string VendorAddress { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string ContactNumber3 { get; set; }
        public string ContactNumber4 { get; set; }
        public string ContactNumber5 { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Vendor Vendor { get; set; }
    }
}
