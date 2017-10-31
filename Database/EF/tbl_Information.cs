namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Information
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string PhoneNumber { get; set; }

        [StringLength(300)]
        public string Email { get; set; }

        public string Addess { get; set; }
    }
}
