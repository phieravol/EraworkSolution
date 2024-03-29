using AppModules.Posts.Admin;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.PostViewModel;
using ViewModels.PostViewModel.Admin;
using System;
using System.Globalization;

namespace Erawork.Pages.Posts.Client
{
	public class IndexModel : PageModel
	{
		private readonly IManagePosts managePosts;
		private readonly UserManager<AppUser> userManager;

		public IndexModel(IManagePosts managePosts, UserManager<AppUser> userManager)
		{
			this.managePosts = managePosts;
			this.userManager = userManager;
		}

		[BindProperty(SupportsGet = true)]
		public PagingPostRequest pagingRequest { get; set; }

		public List<PostVM> PostsPaging { get; set; }

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
                if (Role[0] != "Client")
                {
                    return RedirectToPage("/Forbidden");
                }
            }

            PostsPaging = await managePosts.GetPostPagingAsync(pagingRequest, user);
            TotalPages = (int)Math.Ceiling(PostsPaging.Count() / (double)pagingRequest.PageSize);

            return Page();
        }
    }
}
