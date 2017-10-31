namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DigitalLaptop
    {
        public int ID { get; set; }

        [Required]
        [StringLength(7)]
        public string ProductID { get; set; }

        [StringLength(50)]
        public string CPU { get; set; }

        [StringLength(50)]
        public string RAM { get; set; }

        [StringLength(50)]
        public string HardDrive { get; set; }

        [StringLength(50)]
        public string GraphicCard { get; set; }

        [StringLength(50)]
        public string Connector { get; set; }

        [StringLength(50)]
        public string OS { get; set; }

        [StringLength(50)]
        public string Design { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        public virtual tbl_Product tbl_Product { get; set; }
    }
}
