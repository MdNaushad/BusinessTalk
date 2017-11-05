using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Expenses
    {
        public int ExpenseId { get; set; }
        public int ExpenseTypeId { get; set; }
        public decimal AmountSpent { get; set; }
        public DateTime SpentDate { get; set; }

        public Expensetypes ExpenseType { get; set; }
    }
}
