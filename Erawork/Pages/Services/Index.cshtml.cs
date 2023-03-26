using AppModules.Categories.Public;
using AppModules.Services.Public;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.ServiceViewModel;
using ViewModels.ServiceViewModel.Public;

namespace Erawork.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly IPublicServices publicServices;
        private readonly IPublicCategory publicCategory;

		public IndexModel(IPublicServices publicServices, IPublicCategory publicCategory)
		{
			this.publicServices = publicServices;
            this.publicCategory = publicCategory;
		}

        [BindProperty(SupportsGet = true)] public ServiceFilterRequest PagingRequest { get; set; }
        public List<Category> Categories { get; set; }
		public List<ServicesVM> Services { get; set; }
		public int TotalPages { get; set; }
		public bool HasPreviousPage
		{
			get
			{
				return (PagingRequest.CurrentPage > 1);
			}
		}

		public bool HasNextPage
		{
			get
			{
				return (PagingRequest.CurrentPage < TotalPages);
			}
		}
		public async Task<IActionResult> OnGetAsync()
        {

            Categories = await publicCategory.GetActiveCategoriesAsync();

			if (ModelState.IsValid)
			{
				int TotalRow = await publicServices.CountTotalRecord(PagingRequest);
				Services = await publicServices.GetPublicServicesAsync(PagingRequest);
				TotalPages = (int)Math.Ceiling(TotalRow / (double)PagingRequest.PageSize);
			}
			return Page();
		}
    }
}
