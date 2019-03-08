using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementEntity
{
   public class Menu
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Language { get; set; }
        public String Link { get; set; }
        public Boolean IsActive { get; set; }
    }
}
