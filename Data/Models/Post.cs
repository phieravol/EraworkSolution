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
        public string? PostDetails { get; set; }
        public decimal? Budget { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? CategoryId { get; set; }
    }
}
