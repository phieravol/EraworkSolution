using AppModules.Categories.Manage;
using AppModules.Services.Public;
using AppModules.SubCategories.Admin;
using AppModules.SubCategories.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.ServiceViewModel;
using ViewModels.SubCatesViewModel;

namespace Erawork.Pages.Admin.SubCategories
{
    public class DetailModel : PageModel
    {
		private readonly IManageSubcates serviceSubcate;
		private readonly IPublicServices publicServices;
		private readonly IManageCategory serviceCategory;

		public DetailModel(IManageSubcates serviceSubcate, IPublicServices publicServices, IManageCategory serviceCategory)
		{
			this.serviceSubcate = serviceSubcate;
			this.publicServices = publicServices;
			this.serviceCategory = serviceCategory;
		}

		[BindProperty(SupportsGet = true)] public int subcateId { get; set; }
		public List<ServicesVM> Services { get; set; }
		public string? CategoryName { get; set; }
		public string? SubcategoryName { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			if (subcateId.ToString()=="" || subcateId.ToString().Length==0)
			{
				return NotFound();
			}

			//get sub category name
			var sub = await serviceSubcate.GetSubCateByIdAsync(subcateId);
			SubcategoryName = sub.SubcateName;

			//get all active service of this category
			Services = await publicServices.GetServiceBySubcateAsync(subcateId);
			return Page();
		}

	}
}
