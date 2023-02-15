using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.CategoryVM.Admin
{
    public class CreateCategoryRequest
    {
        [Required]
        [Display(Name = "Category Name")]
        public string? CategoryName { get; set; }

        public IFormFile? CategoryImage { get; set; }

        [Display(Name = "Is Active")]
        public bool? isCategoryActive { get; set; }

        [Display(Name = "Category Description")]
        public string? CategoryDescription { get; set; }
    }
}
