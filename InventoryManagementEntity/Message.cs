using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementEntity
{
   public class Message
    {
        [Key]
        public int Id { get; set; }
        public string MessageContent { get; set; }

        public int? CompanyId { get; set; }
        public int? StaffId { get; set; }
      
        public Company Company { get; set; }

        public Staff Staff { get; set; }

        
        
    }
}
