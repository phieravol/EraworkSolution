using AppModules.Categories.Public;
using AppModules.Posts.Admin;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.PostViewModel;

namespace Erawork.Pages.Posts.Client
{
    public class UpdateModel : PageModel
    {
        private readonly IManagePosts managePosts;
        private readonly IPublicCategory publicCategory;
        public UpdateModel(IManagePosts managePosts, IPublicCategory publicCategory)
        {
            this.managePosts = managePosts;
            this.publicCategory = publicCategory;
        }
        [BindProperty(SupportsGet = true)] public int? Id { get; set; }
        [BindProperty] public Post currentPost { get; set; }
        public List<Category> Categories { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await publicCategory.GetActiveCategoriesAsync();
            currentPost = await managePosts.GetPostByIdAsync(Id);
            if (currentPost == null)
            {
                return NotFound();
            }
            return Page();
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

            if (User != null)
            {
                await managePosts.UpdatePostAsync(currentPost, User);
            }

            return new RedirectToPageResult("./Index");
        }
    }
}
