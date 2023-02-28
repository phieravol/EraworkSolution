using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.PostViewModel.Admin
{
    public class PostCreateRequest
    {
        [Required]
        [Display(Name ="Job Title")]
        public string? PostTitle { get; set; }

        [Required]
        [Display(Name = "Job Details")]
        public string? PostDetails { get; set; }

        [Required]
        [Display(Name = "Sort Description")]
        public string? SortDesc { get; set;}

        [Required]
        [Display(Name = "Range Budgets")]
        public decimal? Budget { get; set; }

        [Required]
        [Display(Name = "Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Public date")]
        public DateTime? PostedDate { get; set; }

        [Required]
        [Display(Name = "Select Category")]
        public int? CategoryId { get; set; }

        [Required]
        [Display(Name = "Posted by")]
        public Guid UserId { get; set; }

        [Display(Name = "Status")]
        public string? PostStatus { get; set; }

        [Display(Name = "Is Public")]
        [DefaultValue(true)]
        public bool isPostPublic { get; set; } = false;

        [Required]
        [Display(Name = "Provider level required")]
        public string? LevelRequired { get; set; }
    }
}
