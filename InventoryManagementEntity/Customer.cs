using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementEntity
{
   public class Customer
    {
        [Key]
        public int Id {get; set;}
        public String Name {get; set;}
        public String Surname {get; set;}
        /*Varsa Kendi Şirketinin Adı*/
        public String CompanyName {get; set;}
        public String Taxnumber {get; set;}

        public int? CompanyId {get; set;}

        public virtual Company Company {get; set;}
    }
}
