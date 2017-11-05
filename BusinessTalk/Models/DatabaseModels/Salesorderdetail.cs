using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Salesorderdetail
    {
        public int SalesOrderId { get; set; }
        public int SalesOrderDetailId { get; set; }
        public short OrderQty { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public string Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Salesorderheader SalesOrder { get; set; }
    }
}
