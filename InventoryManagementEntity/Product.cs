namespace InventoryManagementEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public Product()
        {
            ProductImgs = new HashSet<ProductImg>();


        }
        public int Id { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Content { get; set; }

        public string BarcodeCode { get; set; }

        public string BarcodeCode2 { get; set; }

        public int ShelfNumber { get; set; }

        public int Pieces { get; set; }

        public int MaxPieces { get; set; }

        public int MinPieces { get; set; }

        public int Price { get; set; }

        public int TaxRate { get; set; }

        public Boolean IsActive { get; set; }

        public int? CompanyId { get; set; }

        public int? StoreId { get; set; }





        public virtual Company Company { get; set; }

        public virtual Store Store { get; set; }

        public virtual ICollection<ProductImg> ProductImgs { get; set; }
    }
}
