using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModels.ServiceViewModel.Admin
{
    public class ServiceUpdateRequest
    {
        [Required]
        [Display(Name = "Service ID")]
        public int ServiceId { get; set; }

        [Required]
        [Display(Name = "Service Name")]
        [MaxLength(1000)]
        public string? ServiceTitle { get; set; }

        [Display(Name = "Service Description")]
        public string? ServiceIntro { get; set; }

        [Required]
        [Display(Name = "Select Category")]
        public int? SubCategoryId { get; set; }

        [Display(Name = "Average Stars")]
        public int? TotalStars { get; set; }

        [Display(Name = "Total Clients")]
        public int? TotalClients { get; set; }

        [Required]
        [Display(Name = "Service status")]
        public bool? isServiceActive { get; set; }

        [Display(Name = "Service Image")]
        public IFormFile? ServiceImage { get; set; }

        [Required]
        [Display(Name = "Provider")]
        public Guid UserId { get; set; }
    }
}
