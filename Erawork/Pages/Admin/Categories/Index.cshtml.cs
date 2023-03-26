using AppModules.Categories.Manage;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using ViewModels.CategoryVM.Admin;
using Microsoft.AspNetCore.Http;
using ViewModels.CategoryVM.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Erawork.Pages.Admin.Categories
{
	public class IndexModel : PageModel
    {
        private readonly IManageCategory categoryManage;
        private readonly UserManager<AppUser> userManager;

        public IndexModel(IManageCategory categorFactory, UserManager<AppUser> userManager)
        {
            this.categoryManage = categorFactory;
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public CategoryPagingVM ViewModel { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        [BindProperty]
        public CreateCategoryViewModel? createCategoryVM { get; set; }

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? pageNumber { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (ViewModel.CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (ViewModel.CurrentPage < TotalPages);
            }
        }

        public async Task<IActionResult> OnGetAsync()
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
                return RedirectToPage("/User/Login");
			}
            else
            {
                var Role = await userManager.GetRolesAsync(user);
                if (Role[0] != "Admin")
                {
                    return RedirectToPage("/Forbidden");
                }
            }

			Categories = await categoryManage.GetCategoriesByTermAsync(ViewModel.searchTerm);
            TotalPages = (int)Math.Ceiling(Categories.Count() / (double)ViewModel.PageSize);
            Categories = Categories.Skip((ViewModel.CurrentPage - 1) * ViewModel.PageSize).Take(ViewModel.PageSize).ToList();
            return Page();
        }

        /// <summary>
        /// Create a new category with async
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostCreateAsync()
        {
            await categoryManage.CreateCategoryAsync(createCategoryVM);
            return new RedirectToPageResult("./Index");
        }
    }
}
