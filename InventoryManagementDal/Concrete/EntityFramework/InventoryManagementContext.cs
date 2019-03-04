namespace InventoryManagementDal.Concrete.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using InventoryManagementEntity;

    public partial class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext()
            : base("name=InventoryManagementContext")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Staff> Staffs { get; set;}
        public virtual DbSet<ProductImg> ProductImgs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }


       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Stores)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Company>()
              .HasMany(e => e.Staffs)
              .WithOptional(e => e.Company)
              .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Store)
                .HasForeignKey(e => e.StoreId);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductImgs)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.ProductId);
        }
    }
}
