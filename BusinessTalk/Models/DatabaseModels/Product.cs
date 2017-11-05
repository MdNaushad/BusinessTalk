using System;
using System.Collections.Generic;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class Product
    {
        public Product()
        {
            Transactionhistory = new HashSet<Transactionhistory>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public string Color { get; set; }
        public short? ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public short? ProductSubcategoryId { get; set; }
        public int? ProductModelId { get; set; }
        public string Style { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public string Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Productlistpricehistory Productlistpricehistory { get; set; }
        public Productvendor Productvendor { get; set; }
        public ICollection<Transactionhistory> Transactionhistory { get; set; }
    }
}
