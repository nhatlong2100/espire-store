namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_About
    {
        public int ID { get; set; }

        public string Content { get; set; }

        [StringLength(5)]
        public string ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
