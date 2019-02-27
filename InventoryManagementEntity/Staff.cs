using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementEntity
{
   public class Staff
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public int? CompanyId { get; set; }

        public string Department { get; set; }

        public string Task { get; set; }

        public Boolean IsActive { get; set; }

        public virtual Company Company { get; set; }
    }
}
