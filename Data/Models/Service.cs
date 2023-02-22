using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string? ServiceTitle { get; set; }
        public string? ServiceIntro { get; set; }
        public int? SubCategoryId { get; set; }
        public int? TotalStars { get; set; }
        public int? TotalClients { get; set; }
        public bool? isServiceActive { get; set; }
        public string? ServiceImage { get; set; }
        public Guid UserId { get; set; }

        public virtual SubCategory? SubCategory { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public virtual ICollection<OrderRequest>? OrderRequests { get; set; }

        public virtual ICollection<Pakage>? Pakages { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
        
    }
}
