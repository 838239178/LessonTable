namespace LessonTable.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string usrname { get; set; }

        [Required]
        [StringLength(20)]
        public string pwd { get; set; }

        public int money { get; set; }
    }
}
