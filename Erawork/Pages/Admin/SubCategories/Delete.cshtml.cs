using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.CategoryVM.Admin;

namespace Erawork.Pages.Admin.SubCategories
{
    public class DeleteModel : PageModel
    {
        private readonly IManageSubcates manageSub;
        private readonly UserManager<AppUser> userManager;
        public DeleteModel(IManageSubcates manageSub, UserManager<AppUser> userManager)
        {
            this.manageSub = manageSub;
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        [BindProperty(SupportsGet = true)] public int CateId { get; set; }
        public SubCategory subCategory { get; set; }

        /// <summary>
        /// Redirect user to confirm delete page
        /// </summary>
        /// <returns></returns>
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
            subCategory = await manageSub.GetSubCateByIdAsync(Id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return Page();
        }

        /// <summary>
        /// Delete a subcategory by Id
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            await manageSub.DelSubcateAsync(Id);
            return RedirectToPage("./Index");
        }
    }
}
