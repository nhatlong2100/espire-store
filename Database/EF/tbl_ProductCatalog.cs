namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ProductCatalog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ProductCatalog()
        {
            tbl_Product = new HashSet<tbl_Product>();
        }

        [Key]
        [StringLength(6)]
        public string CatalogProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductTypeID { get; set; }

        [StringLength(50)]
        public string CatalogProductName { get; set; }

        [StringLength(70)]
        public string MetaName { get; set; }

        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Product> tbl_Product { get; set; }
    }
}
