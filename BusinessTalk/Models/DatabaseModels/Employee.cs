using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Employee
    {
        public Employee()
        {
            Purchaseorderheader = new HashSet<Purchaseorderheader>();
            Salesorderheader = new HashSet<Salesorderheader>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string LoginId { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool CurrentFlag { get; set; }
        public string Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Purchaseorderheader> Purchaseorderheader { get; set; }
        public ICollection<Salesorderheader> Salesorderheader { get; set; }
    }
}
