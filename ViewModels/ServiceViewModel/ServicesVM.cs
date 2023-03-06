using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ServiceViewModel
{
	public class ServicesVM
	{
		public int ServiceId { get; set; }
		public string? ServiceTitle { get; set; }
		public string? ServiceIntro { get; set; }
		public int? SubCategoryId { get; set; }
		public string? SubCateName { get; set; }
		public int? TotalStars { get; set; }
		public int? TotalClients { get; set; }
		public bool? isServiceActive { get; set; }
		public string? ServiceImage { get; set; }
		public string? ProviderFirstName { get; set; }
		public string? ProviderLastName { get; set; }
		public List<Pakage>? Pakages { get; set; }
		
	}
}
