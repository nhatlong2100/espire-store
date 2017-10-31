namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_News
    {
        [Key]
        [StringLength(6)]
        public string NewID { get; set; }

        [Required]
        [StringLength(5)]
        public string CategoryNewID { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(5)]
        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(5)]
        public string ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        [StringLength(250)]
        public string SummaryText { get; set; }

        public string Content { get; set; }

        public int View { get; set; }

        public bool Status { get; set; }

        public virtual tbl_NewCategory tbl_NewCategory { get; set; }
    }
}
