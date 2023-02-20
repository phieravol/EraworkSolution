using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SubCatesViewModel.Admin
{
    public class SubcateCreateRequest
    {
        [Required]
        [Display(Name = "SubCategory Name")]
        [StringLength(30, MinimumLength = 3)]
        public string? SubcateName { get; set; }

        [Required]
        [Display(Name = "SubCategory Image")]
        public string? SubcateImage { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool? isSubCateActive { get; set; }

        [Display(Name = "SubCategory Description")]
        public string? SubcateDesc { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public int? CategoryId { get; set; }
    }
}
