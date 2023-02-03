using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int? Stars { get; set; }
        public string? Comment { get; set; }
        public bool? IsHelpfull { get; set; }
        public DateTime? ReviewTime { get; set; }
        public int? ServiceId { get; set; }
        public int? Liked { get; set; }
        public int? Report { get; set; }

        public virtual Service? Service { get; set; }
    }
}
