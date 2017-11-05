using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Transactionhistory
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public decimal ActualCost { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Product Product { get; set; }
    }
}
