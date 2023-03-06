using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModels.PakageViewModel.Provider
{
	public class PakageUpdateRequest: PakageCreateRequest
	{
		[Required]
		[Display(Name = "Pakage Id")]
		public int PakageId { get; set; }
	}
}
