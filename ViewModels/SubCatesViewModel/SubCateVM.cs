using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ServiceViewModel;

namespace ViewModels.SubCatesViewModel
{
    public class SubCateVM
    {
        public int SubCateId { get; set; }
        public string? SubcateName { get; set; }
        public string? SubcateImage { get; set; }
        public bool? isSubCateActive { get; set; }
        public string? SubcateDesc { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set;}
        public List<ServicesVM> Services { get; set; }
    }
}
