using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementEntity
{
    public class CompanyLogo
    {
        [Key]
        public int Id { get; set; }
        public String Folder { get; set; }

        public int? CompanyId { get; set; }

        public virtual  Company Company { get; set; }

    }
}
