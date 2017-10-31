namespace Database.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EspireDbContext : DbContext
    {
        public EspireDbContext()
            : base("name=EspireDbContext")
        {
        }

        public virtual DbSet<tbl_About> tbl_About { get; set; }
        public virtual DbSet<tbl_Customer> tbl_Customer { get; set; }
        public virtual DbSet<tbl_DigitalLaptop> tbl_DigitalLaptop { get; set; }
        public virtual DbSet<tbl_DigitalPhone> tbl_DigitalPhone { get; set; }
        public virtual DbSet<tbl_Guarantee> tbl_Guarantee { get; set; }
        public virtual DbSet<tbl_Information> tbl_Information { get; set; }
        public virtual DbSet<tbl_NewCategory> tbl_NewCategory { get; set; }
        public virtual DbSet<tbl_News> tbl_News { get; set; }
        public virtual DbSet<tbl_Order> tbl_Order { get; set; }
        public virtual DbSet<tbl_OrderDetail> tbl_OrderDetail { get; set; }
        public virtual DbSet<tbl_Position> tbl_Position { get; set; }
        public virtual DbSet<tbl_Product> tbl_Product { get; set; }
        public virtual DbSet<tbl_ProductCatalog> tbl_ProductCatalog { get; set; }
        public virtual DbSet<tbl_Slide> tbl_Slide { get; set; }
        public virtual DbSet<tbl_Staff> tbl_Staff { get; set; }
        public virtual DbSet<tbl_TypeProduct> tbl_TypeProduct { get; set; }
        public virtual DbSet<tbl_Warehouse> tbl_Warehouse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_About>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_DigitalLaptop>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_DigitalPhone>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Guarantee>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Guarantee>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Guarantee>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Information>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Information>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_NewCategory>()
                .Property(e => e.CategoryNewID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_NewCategory>()
                .Property(e => e.MetaName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_NewCategory>()
                .HasMany(e => e.tbl_News)
                .WithRequired(e => e.tbl_NewCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_News>()
                .Property(e => e.NewID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_News>()
                .Property(e => e.CategoryNewID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_News>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_News>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_News>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_News>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Order>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Order>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Order>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_Order>()
                .Property(e => e.Censor)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Order>()
                .HasMany(e => e.tbl_OrderDetail)
                .WithRequired(e => e.tbl_Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_OrderDetail>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_OrderDetail>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_OrderDetail>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_Position>()
                .Property(e => e.TypeUser)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Position>()
                .HasMany(e => e.tbl_Staff)
                .WithRequired(e => e.tbl_Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.ProductTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.CatalogProductID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.MetaName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.EntryPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.SellPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_Product>()
                .HasMany(e => e.tbl_DigitalLaptop)
                .WithRequired(e => e.tbl_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Product>()
                .HasMany(e => e.tbl_DigitalPhone)
                .WithRequired(e => e.tbl_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Product>()
                .HasMany(e => e.tbl_OrderDetail)
                .WithRequired(e => e.tbl_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Product>()
                .HasMany(e => e.tbl_Warehouse)
                .WithRequired(e => e.tbl_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_ProductCatalog>()
                .Property(e => e.CatalogProductID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ProductCatalog>()
                .Property(e => e.ProductTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ProductCatalog>()
                .Property(e => e.MetaName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ProductCatalog>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ProductCatalog>()
                .HasMany(e => e.tbl_Product)
                .WithRequired(e => e.tbl_ProductCatalog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Slide>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Staff>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Staff>()
                .Property(e => e.TypeUser)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Staff>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Staff>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Staff>()
                .Property(e => e.Emaill)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Staff>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TypeProduct>()
                .Property(e => e.ProductTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TypeProduct>()
                .HasMany(e => e.tbl_Product)
                .WithRequired(e => e.tbl_TypeProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Warehouse>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Warehouse>()
                .Property(e => e.PersonUpdating)
                .IsUnicode(false);
        }
    }
}
