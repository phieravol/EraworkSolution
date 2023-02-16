using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SubCategory
    {
        public int SubCateId { get; set; }
        public string? SubcateName { get; set; }
        public string? SubcateImage { get; set; }
        public bool? isSubCateActive { get; set; }
        public string? SubcateDesc { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Service>? Services { get; set; }

    }
}
