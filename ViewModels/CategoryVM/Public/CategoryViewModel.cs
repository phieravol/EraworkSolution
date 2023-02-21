using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.CategoryVM.Public
{
	public class CategoryViewModel
	{
		public int CategoryId { get; set; }
		public string? CategoryName { get; set; }
		public string? CategoryImage { get; set; }
		public bool? isCategoryActive { get; set; }
		public string? CategoryDescription { get; set; }
		List<SubCategory>? subCategories { get; set; }
	}
}
