using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace ViewModels.CategoryVM.Admin
{
	public class CategoryPagingVM : PagingRequestBase
	{
		public string? searchTerm { get; set; }

		public List<Category> categories { get; set; }
	}
}
