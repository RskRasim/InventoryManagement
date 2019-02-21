using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementEntity
{
  public  class Product
    {

        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Content { get; set; }
        public string BarcodeCode { get; set; }
        public string BarcodeCode2 { get; set; }
        public int ShelfNumber { get; set; }
        public int Pieces { get; set; }
        public int MaxPieces { get; set; }
        public int MinPieces { get; set; }
        public Company CompanyId { get; set; }
        public Store StoreId { get; set; }
    }
}
