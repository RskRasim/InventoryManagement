using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InventoryManagementEntity
{
   public class ProductImg
    {
        public int Id { get; set; }
        public object Img { get; set; }
        public int ProductId { get; set; }

        public  virtual Product Product { get; set; }
    }
}
