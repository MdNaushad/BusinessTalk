using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Expensetypes
    {
        public Expensetypes()
        {
            Expenses = new HashSet<Expenses>();
        }

        public int ExpenseTypeId { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Expenses> Expenses { get; set; }
    }
}
