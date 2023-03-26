using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string? PostTitle { get; set; }
        public string? SortDesc { get; set; }
        public string? PostDetails { get; set; }
        public decimal? Budget { get; set; } 
        public DateTime? ExpirationDate { get; set; } 
        public DateTime? PostedDate { get; set; }
        public int? CategoryId { get; set; }
        public Guid UserId { get; set; }
        public string? PostStatus { get; set; }
        public bool IsPostPublic { get; set; }
        public string? LevelRequired { get; set; }

        public virtual Category? Category { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public virtual ICollection<OrderRequest>? OrderRequests { get; set; }
    }
}
