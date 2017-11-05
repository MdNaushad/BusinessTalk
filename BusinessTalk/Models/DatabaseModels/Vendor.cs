using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Vendor
    {
        public Vendor()
        {
            Productvendor = new HashSet<Productvendor>();
        }

        public int VendorId { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Vendorcontact Vendorcontact { get; set; }
        public ICollection<Productvendor> Productvendor { get; set; }
    }
}
