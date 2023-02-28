using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SubCatesViewModel.Public
{
	public class PublicPostPagingRequest : PagingRequestBase
	{
		public string? searchTerm { get; set; }
		public List<int>? CategoryIds { get; set; }
		public bool IsFreeFilter { get; set; }
		public float? minBudget { get; set; }
		public float? maxBudget { get; set;}
		public List<string>? RequiredLevels { get; set; }
	}
}
