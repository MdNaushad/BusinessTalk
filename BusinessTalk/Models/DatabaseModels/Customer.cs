using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Customeraddress Customeraddress { get; set; }
    }
}
