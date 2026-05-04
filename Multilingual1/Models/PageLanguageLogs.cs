namespace Multilingual1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PageLanguageLogs
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LanguageName { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; }
    }
}
