using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementEntity
{
   public class Staff
    {
       
        public int Id { get; set; }
        //[MaxLength(30)]
        //[Required(ErrorMessage = "Username is Mandatory")]
        public string Username { get; set; }
        //[MinLength(6)]
        //[Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }
        //[MaxLength(35)]
        //[Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
        //[MaxLength(35)]
        //[Required(ErrorMessage = "Surname is mandatory")]
        public string Surname { get; set; }
        //[MaxLength(13)]
        public string Phone { get; set; }

        public int? CompanyId { get; set; }
        //[MaxLength(40)]
        public string Department { get; set; }
       // [MaxLength(35)]
        public string Task { get; set; }

        public Boolean IsActive { get; set; }

        public virtual Company Company { get; set; }
    }
}
