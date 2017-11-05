using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Loanhistory
    {
        public int LoanId { get; set; }
        public int BorrowerId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Loans Loan { get; set; }
    }
}
