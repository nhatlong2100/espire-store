namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_OrderDetail
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderID { get; set; }

        [Required]
        [StringLength(7)]
        public string ProductID { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public virtual tbl_Order tbl_Order { get; set; }

        public virtual tbl_Product tbl_Product { get; set; }
    }
}
