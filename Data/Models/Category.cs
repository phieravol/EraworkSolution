using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryImage { get; set; }
        public bool? isCategoryActive { get; set; }
        public string? CategoryDescription { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
