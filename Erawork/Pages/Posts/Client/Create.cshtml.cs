using AppModules.Categories.Manage;
using AppModules.Categories.Public;
using AppModules.Posts.Admin;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.PostViewModel.Admin;

namespace Erawork.Pages.Posts.Client
{
    public class CreateModel : PageModel
    {
        private readonly IManagePosts managePosts;
        private readonly UserManager<AppUser> userManager;
        private readonly IPublicCategory publicCategory;
        public CreateModel(IManagePosts managePosts, UserManager<AppUser> userManager, IPublicCategory publicCategory)
        {
            this.managePosts = managePosts;
            this.userManager = userManager;
            this.publicCategory = publicCategory;
        }

        [BindProperty] public PostCreateRequest createRequest { get; set; }

        public List<Category> Categories { get; set; }

        public async Task OnGetAsync()
        {
            
            Categories = await publicCategory.GetActiveCategoriesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // 1. Get User Session
            string? rawUser = HttpContext.Session.GetString("User");
            AppUser User = null;
            if (!string.IsNullOrEmpty(rawUser))
            {
                User = JsonConvert.DeserializeObject<AppUser>(rawUser);
            }

            if (User!=null)
            {
                await managePosts.CreatePostAsync(createRequest, User);
            }

            return new RedirectToPageResult("./Index");
        }
    }
}
