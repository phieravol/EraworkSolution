using AppModules.Categories.Manage;
using AppModules.Services.Admin;
using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.ServiceViewModel;
using ViewModels.ServiceViewModel.Admin;
using ViewModels.SubCatesViewModel;
using ViewModels.SubCatesViewModel.Admin;

namespace Erawork.Pages.Services.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IManageServices manageServices;
		private readonly UserManager<AppUser> userManager;
		private readonly IManageSubcates manageSubcates;
		public IndexModel(IManageServices manageServices, UserManager<AppUser> userManager, IManageSubcates manageSubcates)
		{
			this.manageServices = manageServices;
			this.userManager = userManager;
			this.manageSubcates = manageSubcates;
		}

        [BindProperty(SupportsGet =true)]
        public ServicePagingRequest? pagingRequest { get; set; }

        [BindProperty]
        public ServicesCreateRequest createRequest { get; set; }

        public List<ServicesVM> servicesPaging { get; set; }
		public List<SubCategory>? subCategories { get; set; }
		public int TotalPages { get; set; }
		public bool HasPreviousPage
		{
			get
			{
				return (pagingRequest.CurrentPage > 1);
			}
		}

		public bool HasNextPage
		{
			get
			{
				return (pagingRequest.CurrentPage < TotalPages);
			}
		}
		public async Task OnGetAsync()
        {
			//get user session
			string? rawUser = HttpContext.Session.GetString("User");
			AppUser? user = null;
			if (rawUser != null)
			{
				user = JsonConvert.DeserializeObject<AppUser>(rawUser);
			}
			if (user == null)
			{
                HttpContext.Response.Clear();
                HttpContext.Response.StatusCode = 404;

                HttpContext.Response.Redirect("/Errors/Error404");
            }
			else if (ModelState.IsValid)
			{
				servicesPaging = await manageServices.PagingServicesAsync(pagingRequest, user.UserName);
				subCategories = await manageSubcates.GetSubCatesAsync();
				TotalPages = (int)Math.Ceiling(servicesPaging.Count() / (double)pagingRequest.PageSize);
			}
		}

        public async Task<IActionResult> OnPostCreateAsync()
		{
            // 1. Get User Session
            string? rawUser = HttpContext.Session.GetString("User");
            AppUser? User = JsonConvert.DeserializeObject<AppUser>(rawUser);
            
			if (ModelState.IsValid && User!=null)
			{
                await manageServices.CreateServiceAsync(createRequest, User);
            }
            return new RedirectToPageResult("./Index");
        }
    }
}
