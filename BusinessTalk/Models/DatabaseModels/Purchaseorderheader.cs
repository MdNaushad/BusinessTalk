﻿using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Purchaseorderheader
    {
        public int PurchaseOrderId { get; set; }
        public sbyte RevisionNumber { get; set; }
        public sbyte Status { get; set; }
        public int EmployeeId { get; set; }
        public int VendorId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Employee Employee { get; set; }
        public Purchaseorderdetail Purchaseorderdetail { get; set; }
    }
}
