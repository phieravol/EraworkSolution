using AppModules.Categories.Manage;
using AppModules.Categories.Public;
using AppModules.Users.Public;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Erawork.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IManageCategory manageCategory;
        private readonly IPublicCategory publicCategory;
        private readonly IPublicUser publicUser;
        private readonly UserManager<AppUser> userManager;

		public IndexModel(ILogger<IndexModel> logger, IManageCategory manageCategory, IPublicCategory publicCategory, UserManager<AppUser> userManager, IPublicUser publicUser)
		{
            this.manageCategory = manageCategory;
            this.logger = logger;
            this.publicCategory = publicCategory;
            this.userManager = userManager;
            this.publicUser = publicUser;
		}
        public string RoleUser { get; set; }
        public List<Category> Categories { get; set; }
        public async Task OnGetAsync()
        {
            string? rawUser = HttpContext.Session.GetString("User");
            AppUser? user = null;
            if (rawUser != null)
            {
                user = JsonConvert.DeserializeObject<AppUser>(rawUser);
                var roles = await userManager.GetRolesAsync(user);
                RoleUser= roles[0];
            }
            Categories = await publicCategory.GetActiveCategoriesAsync();
        }
    }
}