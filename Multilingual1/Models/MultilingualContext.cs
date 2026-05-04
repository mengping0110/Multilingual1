using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Multilingual1.Models
{
    public partial class MultilingualContext : DbContext
    {
        public MultilingualContext()
            : base("name=MultilingualContext")
        {
        }

        public virtual DbSet<PageLanguageLogs> PageLanguageLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
