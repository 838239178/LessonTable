using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LessonTable.Model
{
    public partial class LessonModel : DbContext
    {
        public LessonModel()
            : base("name=LessonModel")
        {
        }

        public virtual DbSet<account> account { get; set; }
        public virtual DbSet<lesson> lesson { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.usrname)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.pwd)
                .IsUnicode(false);

            modelBuilder.Entity<lesson>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<lesson>()
                .Property(e => e.teacher)
                .IsUnicode(false);

            modelBuilder.Entity<lesson>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<lesson>()
                .Property(e => e.mode)
                .IsUnicode(false);
        }
    }
}
