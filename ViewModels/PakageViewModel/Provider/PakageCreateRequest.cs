using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.PakageViewModel.Provider
{
    public class PakageCreateRequest
    {
        [Required]
        [Display(Name = "Service Id")]
        public int ServiceId { get; set; }

        [Required]
        [Display(Name = "Pakage Name")]
        public string PakageName { get; set; }

        [Required]
        [Display(Name = "Pakage Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Limit Update")]
        public string RevisionLimit { get; set; }

        [Required]
        [Display(Name = "Delivery on")]
        public int DeliveryDay { get; set; }

        [Display(Name = "Is this pakage update")]
        public string IsActive { get; set; }

	}
}
