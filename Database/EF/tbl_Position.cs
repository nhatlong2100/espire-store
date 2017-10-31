namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Position()
        {
            tbl_Staff = new HashSet<tbl_Staff>();
        }

        [Key]
        [StringLength(5)]
        public string TypeUser { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }

        [StringLength(200)]
        public string Describe { get; set; }

        public bool Show { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Staff> tbl_Staff { get; set; }
    }
}
