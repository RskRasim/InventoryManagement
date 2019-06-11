namespace InventoryManagementEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            Products = new HashSet<Product>();
            Stores = new HashSet<Store>();
            Staffs = new HashSet<Staff>();
            CompanyAddresses = new HashSet<CompanyAddress>();
            CompanyLogoes = new HashSet<CompanyLogo>();
            Customers = new HashSet<Customer>();
            Messages = new HashSet<Message>();
            Roles = new HashSet<Role>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string TaxNumber { get; set; }

        public string Password { get; set; }

        public Boolean IsActive { get; set; }
 
        public string Email { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store> Stores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staffs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }

        public virtual ICollection<CompanyLogo> CompanyLogoes { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}