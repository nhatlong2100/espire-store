namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Staff
    {
        [Key]
        [StringLength(5)]
        public string UserID { get; set; }

        [Required]
        [StringLength(5)]
        public string TypeUser { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(100)]
        public string Emaill { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public bool Sex { get; set; }

        public DateTime BirthDay { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public bool Status { get; set; }

        public virtual tbl_Position tbl_Position { get; set; }
    }
}
