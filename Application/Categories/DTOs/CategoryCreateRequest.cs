using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Categories.DTOs
{
    public class CategoryCreateRequest
    {
        public string? CategoryName { get; set; }
        public byte[]? CategoryImage { get; set; }
        public bool? isCategoryActive { get; set; }
        public string? CategoryDescription { get; set; }
    }
}
