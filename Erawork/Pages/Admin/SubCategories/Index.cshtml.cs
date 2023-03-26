using AppModules.Categories.Manage;
using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ViewModels.SubCatesViewModel;
using ViewModels.SubCatesViewModel.Admin;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erawork.Pages.Admin.SubCategories
{
    public class IndexModel : PageModel
    {
        private readonly IManageSubcates manageSubcates;
        private readonly IManageCategory manageCategory;
        private readonly UserManager<AppUser> userManager;
        public IndexModel(IManageSubcates manageSubcates, IManageCategory manageCategory, UserManager<AppUser> userManager)
        {
            this.manageSubcates = manageSubcates;
            this.manageCategory = manageCategory;
            this.userManager = userManager;
        }

        [BindProperty (SupportsGet = true)]
        public SubcatePagingRequest pagingRequest { get; set; }
        
        [BindProperty (SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public SubcateCreateRequest createRequest { get; set; }

        public List<SubCateVM> subcates { get; set; }
        public List<Category> categories { get; set; }
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
            categories = await manageCategory.GetCategoriesAsync();
            subcates = await manageSubcates.PagingSubcategoriesAsync(pagingRequest, id);
            List<SubCategory> listSubCate = await manageSubcates.GetSubCatesAsync();
            TotalPages = (int)Math.Ceiling(listSubCate.Count() / (double)pagingRequest.PageSize);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            subcates = await manageSubcates.PagingSubcategoriesAsync(pagingRequest, id);
            categories = await manageCategory.GetCategoriesAsync();
            await manageSubcates.CreateSubcateAsync(createRequest);
            List<SubCategory> listSubCate = await manageSubcates.GetSubCatesAsync();
            TotalPages = (int)Math.Ceiling(listSubCate.Count() / (double)pagingRequest.PageSize);
            return RedirectToPage("./Index");
        }
    }
}
