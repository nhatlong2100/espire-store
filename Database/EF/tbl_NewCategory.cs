namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_NewCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_NewCategory()
        {
            tbl_News = new HashSet<tbl_News>();
        }

        [Key]
        [StringLength(5)]
        public string CategoryNewID { get; set; }

        [StringLength(50)]
        public string CategoryNewName { get; set; }

        [StringLength(70)]
        public string MetaName { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? ShowOnHome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_News> tbl_News { get; set; }
    }
}
