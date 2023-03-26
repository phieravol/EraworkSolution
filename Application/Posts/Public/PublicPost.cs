using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.PostViewModel;
using ViewModels.PostViewModel.Public;
using ViewModels.ServiceViewModel;

namespace AppModules.Posts.Public
{
    public class PublicPost : IPublicPost
	{
		private readonly EraWorkContext context;

		public PublicPost(EraWorkContext context)
		{
			this.context = context;
		}

		public async Task<List<PostVM>> GetNewPostAsync()
		{
			List<PostVM> ActivePosts = GetActivePosts();
			ActivePosts.OrderByDescending(x => x.PostedDate);
			return ActivePosts;
		}

		private List<PostVM> GetActivePosts()
		{
			var query = from p in context.Posts
						join u in context.AppUsers on p.UserId equals u.Id
						join c in context.Categories on p.CategoryId equals c.CategoryId
						where p.IsPostPublic == true
						select new { p, u, c };
			var data = query.Take(5)
				.Select(x => new PostVM()
				{
					PostId = x.p.PostId,
					PostTitle = x.p.PostTitle,
					PostDetails = x.p.PostDetails,
					PostedDate = x.p.PostedDate,

					PostStatus = x.p.PostStatus,
					isPostPublic = x.p.IsPostPublic,
					Budget = x.p.Budget,
					Category = x.c,
					SortDesc = x.p.SortDesc,
					ExpirationDate = x.p.ExpirationDate,
					LevelRequired = x.p.LevelRequired,
					CategoryId = x.p.CategoryId,
					ClientName = $"{x.u.FirstName} {x.u.LastName}"
				});
			return data.ToList();
		}

		public async Task<List<PostVM>> GetPostFilterPaging(PublicPostPagingRequest pagingRequest)
		{
			var query = from p in context.Posts
						join u in context.AppUsers on p.UserId equals u.Id
						join c in context.Categories on p.CategoryId equals c.CategoryId
						where p.IsPostPublic == true
						select new { p, u, c };

			// 2. Search
			if (!string.IsNullOrEmpty(pagingRequest.searchTerm))
			{
				query = query.Where(x => x.p.PostTitle.Contains(pagingRequest.searchTerm) || x.p.SortDesc.Contains(pagingRequest.searchTerm) || x.p.PostDetails.Contains(pagingRequest.searchTerm));

			}
			if (pagingRequest.CategoryIds != null && pagingRequest.CategoryIds.Count > 0)
			{
				query = query.Where(x => pagingRequest.CategoryIds.Contains((int)x.p.CategoryId));
			}

			if (pagingRequest.RequiredLevels!=null && pagingRequest.RequiredLevels.Count > 0)
			{
				query = query.Where(x => pagingRequest.RequiredLevels.Contains(x.p.LevelRequired));
			}

			if (!pagingRequest.isAnyFilter && pagingRequest.budgetRange != null)
			{
				string rawBudget = pagingRequest.budgetRange.Trim().Replace("$", "");
				string[] rawBudgetSplit = rawBudget.Split(" - ");
			}

			var data = query.Skip((pagingRequest.CurrentPage - 1) * pagingRequest.PageSize).Take(pagingRequest.PageSize)
				.Select(x => new PostVM()
				{
					PostId = x.p.PostId,
					PostTitle = x.p.PostTitle,
					PostDetails = x.p.PostDetails,
					PostedDate = x.p.PostedDate,
					PostStatus = x.p.PostStatus,
					isPostPublic = x.p.IsPostPublic,
					Budget = x.p.Budget,
					Category = x.c,
					SortDesc = x.p.SortDesc,
					ExpirationDate = x.p.ExpirationDate,
					LevelRequired = x.p.LevelRequired,
					CategoryId = x.p.CategoryId,
					ClientName = $"{x.u.FirstName} {x.u.LastName}"
				});
			return await data.ToListAsync();
		}

		public async Task<List<PostVM>> GetTopPosts()
		{
			var query = from p in context.Posts
						join u in context.AppUsers on p.UserId equals u.Id
						join c in context.Categories on p.CategoryId equals c.CategoryId
						where p.IsPostPublic == true
						select new { p, u, c };
			var data = await query.OrderByDescending(x => x.p.Budget).Select(x => new PostVM()
			{
                PostId = x.p.PostId,
                PostTitle = x.p.PostTitle,
                PostDetails = x.p.PostDetails,
                PostedDate = x.p.PostedDate,
                PostStatus = x.p.PostStatus,
                isPostPublic = x.p.IsPostPublic,
                Budget = x.p.Budget,
                Category = x.c,
                SortDesc = x.p.SortDesc,
                ExpirationDate = x.p.ExpirationDate,
                LevelRequired = x.p.LevelRequired,
                CategoryId = x.p.CategoryId,
                ClientName = $"{x.u.FirstName} {x.u.LastName}"
            }).ToListAsync();
			return data;
		}
	}
}
