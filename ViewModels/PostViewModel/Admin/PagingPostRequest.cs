using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.PostViewModel.Admin
{
	public class PagingPostRequest : PagingRequestBase
	{
		public string? searchTerm { get; set; }

	}
}
