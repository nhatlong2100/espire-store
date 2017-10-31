namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DigitalPhone
    {
        public int ID { get; set; }

        [Required]
        [StringLength(7)]
        public string ProductID { get; set; }

        [StringLength(50)]
        public string Screen { get; set; }

        [StringLength(50)]
        public string OS { get; set; }

        [StringLength(50)]
        public string FrontCamea { get; set; }

        [StringLength(50)]
        public string CameraAfter { get; set; }

        [StringLength(50)]
        public string CPU { get; set; }

        [StringLength(50)]
        public string RAM { get; set; }

        [StringLength(50)]
        public string ROM { get; set; }

        [StringLength(50)]
        public string MemoryStick { get; set; }

        [StringLength(50)]
        public string SIMCard { get; set; }

        [StringLength(50)]
        public string BatteryCapacity { get; set; }

        public virtual tbl_Product tbl_Product { get; set; }
    }
}
