using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Loans
    {
        public int LoanId { get; set; }
        public DateTime LoanTakenDate { get; set; }
        public sbyte Status { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime? LoanCompletionDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Loanhistory Loanhistory { get; set; }
    }
}
