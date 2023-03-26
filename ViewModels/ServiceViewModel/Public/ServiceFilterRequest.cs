using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ServiceViewModel.Public
{
	public class ServiceFilterRequest: PagingRequestBase
	{
		public List<int>? CategoryIds { get; set; }
		public string? budgetRange { get; set; }
		public List<string>? RequiredLevels { get; set; }
		public string? SearchTerm { get; set; }
		public bool isAnyFilter { get; set; }
		public int PageSize { get; set; } = 9;
		
	}
}
