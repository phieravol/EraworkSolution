using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.PostViewModel.Public
{
    public class PublicPostPagingRequest : PagingRequestBase
    {
        public string? searchTerm { get; set; }
        public List<int>? CategoryIds { get; set; }
        public bool isAnyFilter { get; set; }
        public string? budgetRange { get; set; }

		public List<string>? RequiredLevels { get; set; }
    }
}
