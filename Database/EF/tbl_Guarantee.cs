namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Guarantee
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderID { get; set; }

        [StringLength(7)]
        public string ProductID { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public virtual tbl_Product tbl_Product { get; set; }
    }
}
