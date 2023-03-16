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
					UserName = x.u.UserName,
					SubCategoryId = x.sub.SubCateId,
					SubCateName = x.sub.SubcateName,
					TotalClients = x.s.TotalClients,
					TotalStars = x.s.TotalStars,
					Avatar = x.u.UserAvatar,
				});
			return await data.ToListAsync();
		}

		public async Task<ServicesVM> GetServiceDetailAsync(int detailId)
		{
			var query = from s in context.Services
						join u in context.AppUsers on s.UserId equals u.Id
						join sub in context.SubCategories on s.SubCategoryId equals sub.SubCateId
						join c in context.Categories on sub.CategoryId equals c.CategoryId
						where s.ServiceId == detailId
						select new { s, u, sub, c };
			//var services = query.FirstOrDefaultAsync();
			var services = query.Select(x => new ServicesVM()
			{
				ServiceId = x.s.ServiceId,
				ServiceTitle = x.s.ServiceTitle,
				ServiceIntro = x.s.ServiceIntro,
				ServiceImage = x.s.ServiceImage,
				isServiceActive = x.s.isServiceActive,
				ProviderFirstName = x.u.FirstName,
				ProviderLastName = x.u.LastName,
				Avatar= x.u.UserAvatar,
				TotalStars= x.s.TotalStars,
				TotalClients= x.s.TotalClients,
				SubCategoryId = x.s.SubCategoryId,
				SubCateName = x.sub.SubcateName,
				MemberSince = x.u.MemberSince,
				CategoryName = x.c.CategoryName
			});

			return await services.FirstOrDefaultAsync();
		}

        
        private async Task<List<ServicesVM>> GetRawActiveServicesAsync()
        {
            var query = from s in context.Services
                            //join p in context.Pakages on s.ServiceId equals p.ServiceId
                        join sub in context.SubCategories on s.SubCategoryId equals sub.SubCateId
                        join c in context.Categories on sub.CategoryId equals c.CategoryId
                        join u in context.AppUsers on s.UserId equals u.Id
                        where s.isServiceActive == true
                        select new { s, sub, c, u };
            var data = query.Take(6).Select(x => new ServicesVM()
            {
                ServiceId = x.s.ServiceId,
                ServiceTitle = x.s.ServiceTitle,
                ServiceIntro = x.s.ServiceIntro,
                ServiceImage = x.s.ServiceImage,
                isServiceActive = x.s.isServiceActive,
                ProviderFirstName = x.u.FirstName,
                ProviderLastName = x.u.LastName,
                Avatar = x.u.UserAvatar,
                TotalStars = x.s.TotalStars,
                TotalClients = x.s.TotalClients,
                SubCategoryId = x.s.SubCategoryId,
                SubCateName = x.sub.SubcateName,
                MemberSince = x.u.MemberSince,
                CategoryName = x.c.CategoryName
            });
            List<ServicesVM> list = await data.ToListAsync();
            return list;
        }

        public async Task<List<ServicesVM>> getTopRateService()
        {
            List<ServicesVM> Services = await GetRawActiveServicesAsync();
            Services.OrderByDescending(x => x.TotalStars);
            return Services;
        }
    }
}
