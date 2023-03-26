using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SubCatesViewModel.Admin
{
    public class SubcatePagingRequest : PagingRequestBase
    {
        public string? searchTerm { get; set; }
        public List<int>? CategoryIds { get; set; }
        
    }
}
