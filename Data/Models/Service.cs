using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Service
    {
        public int ReviewId { get; set; }

        public string ServiceTitle { get; set; }
        public int? Stars { get; set; }
        public string? Comment { get; set; }
        public bool? IsHelpfull { get; set; }
        public DateTime? ReviewTime { get; set; }
        public int? ServiceId { get; set; }
        public int? Liked { get; set; }
        public int? Report { get; set; }
        public bool isServiceActive { get; set; }

        public virtual SubCategory? SubCategory { get; set; }
        public virtual ICollection<OrderRequest>? OrderRequests { get; set; }

        public virtual ICollection<Pakage>? Pakages { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
        
    }
}
