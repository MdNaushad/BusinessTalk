using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Loancustomers
    {
        public int BorrowerId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
