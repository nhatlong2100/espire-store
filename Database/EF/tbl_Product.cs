namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Product()
        {
            tbl_DigitalLaptop = new HashSet<tbl_DigitalLaptop>();
            tbl_DigitalPhone = new HashSet<tbl_DigitalPhone>();
            tbl_Guarantee = new HashSet<tbl_Guarantee>();
            tbl_OrderDetail = new HashSet<tbl_OrderDetail>();
            tbl_Warehouse = new HashSet<tbl_Warehouse>();
        }

        [Key]
        [StringLength(7)]
        public string ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductTypeID { get; set; }

        [Required]
        [StringLength(6)]
        public string CatalogProductID { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(150)]
        public string MetaName { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "image")]
        public byte[] QRCode { get; set; }

        public decimal? EntryPrice { get; set; }

        public decimal? SellPrice { get; set; }

        public decimal? PromotionPrice { get; set; }

        public DateTime? StartDay { get; set; }

        public DateTime? EndDay { get; set; }

        [StringLength(250)]
        public string Promotion { get; set; }

        [StringLength(250)]
        public string Guarantee { get; set; }

        [StringLength(250)]
        public string InTheBox { get; set; }

        public string Describe { get; set; }

        public int? View { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_DigitalLaptop> tbl_DigitalLaptop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_DigitalPhone> tbl_DigitalPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Guarantee> tbl_Guarantee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_OrderDetail> tbl_OrderDetail { get; set; }

        public virtual tbl_ProductCatalog tbl_ProductCatalog { get; set; }

        public virtual tbl_TypeProduct tbl_TypeProduct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Warehouse> tbl_Warehouse { get; set; }
    }
}
