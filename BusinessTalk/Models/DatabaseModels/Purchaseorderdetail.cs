using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Purchaseorderdetail
    {
        public int PurchaseOrderId { get; set; }
        public int PurchaseOrderDetailId { get; set; }
        public short OrderQty { get; set; }
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Purchaseorderheader PurchaseOrder { get; set; }
    }
}
