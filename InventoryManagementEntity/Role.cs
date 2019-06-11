using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementEntity
{
   public  class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
