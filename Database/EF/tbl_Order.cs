namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Order()
        {
            tbl_OrderDetail = new HashSet<tbl_OrderDetail>();
        }

        [Key]
        [StringLength(20)]
        public string OrderID { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        public decimal? TotalPrice { get; set; }

        [StringLength(5)]
        public string Censor { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_OrderDetail> tbl_OrderDetail { get; set; }
    }
}
