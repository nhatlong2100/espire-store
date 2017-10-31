namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Warehouse
    {
        public int ID { get; set; }

        [Required]
        [StringLength(7)]
        public string ProductID { get; set; }

        public int? Quantity { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(5)]
        public string PersonUpdating { get; set; }

        public virtual tbl_Product tbl_Product { get; set; }
    }
}
