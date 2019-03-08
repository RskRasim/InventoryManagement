using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InventoryManagementEntity
{
   public class ProductImg
    {
        [Key]
        public int Id { get; set; }
        public String Img { get; set; }
        public int? ProductId { get; set; } 

        public  virtual Product Product { get; set; }
    }
}
