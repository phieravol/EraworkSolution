using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.PostViewModel;
using ViewModels.ServiceViewModel;
using ViewModels.ServiceViewModel.Public;

namespace AppModules.Services.Public
{
	public class PublicServices : IPublicServices
	{
		private readonly EraWorkContext context;

		public PublicServices(EraWorkContext context)
		{
			this.context = context;
		}

		public async Task<List<ServicesVM>> GetPublicServicesAsync(ServiceFilterRequest pagingRequest)
		{
			var query = from s in context.Services
						//join p in context.Pakages on s.ServiceId equals p.ServiceId
						join sub in context.SubCategories on s.SubCategoryId equals sub.SubCateId
						join c in context.Categories on sub.CategoryId equals c.CategoryId
						join u in context.AppUsers on s.UserId equals u.Id
						where s.isServiceActive == true
						select new {s, sub, c, u};

			// 2. Search
			if (!string.IsNullOrEmpty(pagingRequest.SearchTerm))
			{
				query = query.Where(x => x.s.ServiceTitle.Contains(pagingRequest.SearchTerm) || x.s.ServiceIntro.Contains(pagingRequest.SearchTerm));

			}
			if (pagingRequest.CategoryIds != null && pagingRequest.CategoryIds.Count > 0)
			{
				query = query.Where(x => pagingRequest.CategoryIds.Contains((int)x.c.CategoryId));
			}
			if (pagingRequest.RequiredLevels != null && pagingRequest.RequiredLevels.Count > 0)
			{
				query = query.Where(x => pagingRequest.RequiredLevels.Contains(x.u.UserLevel));
			}
			var data = query.Skip((pagingRequest.CurrentPage - 1) * pagingRequest.PageSize).Take(pagingRequest.PageSize)
				.Select(x => new ServicesVM()
				{
					ServiceId = x.s.ServiceId,
					ServiceTitle= x.s.ServiceTitle,
					ServiceIntro= x.s.ServiceIntro,
					ServiceImage= x.s.ServiceImage,
					isServiceActive = x.s.isServiceActive,
					ProviderFirstName = x.u.FirstName,
					ProviderLastName = x.u.LastName,
					SubCategoryId = x.sub.SubCateId,
					SubCateName = x.sub.SubcateName,
					TotalClients = x.s.TotalClients,
					TotalStars = x.s.TotalStars,
					Avatar = x.u.UserAvatar,
				});
			return await data.ToListAsync();
		}
	}
}
