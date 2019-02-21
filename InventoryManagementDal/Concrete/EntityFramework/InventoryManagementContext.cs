using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementEntity
{
    class InventoryManagementContext:DbContext
    {
        public DbSet<Company> Company {get;set;}
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
    }
}
