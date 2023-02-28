using AppModules.Categories.Manage;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.PostViewModel;
using ViewModels.PostViewModel.Admin;

namespace AppModules.Posts.Admin
{
	
	public class ManagePosts : IManagePosts
	{
		private readonly EraWorkContext context;
		private readonly IManageCategory manageCategory;
		public ManagePosts(EraWorkContext context, IManageCategory manageCategory)
		{
			this.context = context;
			this.manageCategory = manageCategory;
		}

        public async Task CreatePostAsync(PostCreateRequest createRequest, AppUser user)
        {
			Post post = new Post()
			{
				PostTitle = createRequest.PostTitle,
				PostDetails = createRequest.PostDetails,
				SortDesc = createRequest.SortDesc,
				Budget = createRequest.Budget,
				ExpirationDate= createRequest.ExpirationDate,
				PostedDate= createRequest.PostedDate,
				CategoryId = createRequest.CategoryId,
				UserId= user.Id,
				LevelRequired= createRequest.LevelRequired,
				IsPostPublic = createRequest.isPostPublic,
				PostStatus = createRequest.isPostPublic == true ? "On Going" : "Draft"
			};

			await context.AddAsync(post);
			await context.SaveChangesAsync();
        }

		public async Task DeletePostAsync(int postId)
		{
			Post post = await GetPostByIdAsync(postId);
			context.Posts.Remove(post);
			await context.SaveChangesAsync();
		}

		public async Task<Post> GetPostByIdAsync(int? id)
		{
			var query = from p in context.Posts
						where p.PostId == id
						select p;

			Post? post = await query.FirstOrDefaultAsync();
			post.Category = await manageCategory.GetCategoryByIdAsync(post.CategoryId);
			return post;
		}


		/// <summary>
		/// get all post of current user with paging
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<List<PostVM>> GetPostPagingAsync(PagingPostRequest request, AppUser User)
		{
			//1. get all post
			var query = from p in context.Posts
						join c in context.Categories on p.CategoryId equals c.CategoryId
						join u in context.AppUsers on p.UserId equals u.Id
						where u.UserName == User.UserName
						select new {p, c};

			//2. search posts
			if (!string.IsNullOrEmpty(request.searchTerm))
			{
				query = query.Where(x => x.p.PostTitle.Contains(request.searchTerm) || x.p.PostDetails.Contains(request.searchTerm));
			}

			//3. paging
			var data = query.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize)
				.Select(x => new PostVM()
				{
					PostId = x.p.PostId,
					PostTitle = x.p.PostTitle,
					PostDetails = x.p.PostDetails,
					SortDesc = x.p.SortDesc,
					Budget = x.p.Budget,
					PostedDate = x.p.PostedDate,
					PostStatus = x.p.PostStatus,
					isPostPublic = x.p.IsPostPublic,
					ExpirationDate = x.p.ExpirationDate,
					LevelRequired = x.p.LevelRequired,
					Category = x.c,
					CategoryId = x.p.CategoryId,
					UserId = x.p.UserId,
					ClientName = $"{User.FirstName} {User.LastName}",
				});
			return await data.ToListAsync();
		}

        public async Task UpdatePostAsync(Post currentPost, AppUser user)
        {
			currentPost.PostedDate = DateTime.Now;
			currentPost.UserId = user.Id;
			currentPost.PostStatus = currentPost.PostStatus == "on" ? "Available" : "Canceled";

            context.Posts.Update(currentPost);
			await context.SaveChangesAsync();
        }
    }
}
