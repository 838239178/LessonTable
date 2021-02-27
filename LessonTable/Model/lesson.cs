namespace LessonTable.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lesson")]
    public partial class lesson
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(20)]
        public string teacher { get; set; }

        [StringLength(50)]
        public string location { get; set; }

        public int? startweek { get; set; }

        public int? endweek { get; set; }

        public int? day { get; set; }

        public int? time { get; set; }

        [StringLength(10)]
        public string mode { get; set; }
    }
}
