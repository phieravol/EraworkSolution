using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ServiceViewModel.Public
{
	public class ServiceFilterRequest
	{
		public int[]? CategoryIds { get; set; }
		public int[]? PriceOptions { get; set; }
		public int[]? ProviderLevels { get; set; }
		public string? SearchTerm { get; set; }
	}
}
