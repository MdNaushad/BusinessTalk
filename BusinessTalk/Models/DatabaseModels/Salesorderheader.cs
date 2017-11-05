using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Salesorderheader
    {
        public int SalesOrderId { get; set; }
        public sbyte RevisionNumber { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public sbyte Status { get; set; }
        public string SalesOrderNumber { get; set; }
        public int? CustomerId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Employee Employee { get; set; }
        public Salesorderdetail Salesorderdetail { get; set; }
    }
}
