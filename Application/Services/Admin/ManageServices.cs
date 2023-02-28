using AppModules.GeneralModule;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ServiceViewModel;
using ViewModels.ServiceViewModel.Admin;
using ViewModels.SubCatesViewModel;
using ViewModels.SubCatesViewModel.Admin;

namespace AppModules.Services.Admin
{
	public class ManageServices : IManageServices
	{
		private readonly EraWorkContext context;
		private readonly ISaveImage saveImage;
		public ManageServices(EraWorkContext context, ISaveImage saveImage)
		{
			this.context = context;
            this.saveImage= saveImage;
		}
        public async Task CreateServiceAsync(ServicesCreateRequest request, AppUser User)
        {
			string folderPath = "assets/images/services";

            Service service = new Service()
			{
				ServiceTitle = request.ServiceTitle,
				ServiceIntro = request.ServiceIntro,
				ServiceImage = await saveImage.SaveImageAsync(request.ServiceImage, folderPath),
				SubCategoryId = request.SubCategoryId,
				isServiceActive = request.isServiceActive,
				TotalClients = request.TotalClients,
				TotalStars = request.TotalStars,
				UserId = User.Id,
			};

			await context.AddAsync(service);
			await context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int Id)
        {

			Service service = await GetServiceByIdAsync(Id);
			context.Services.Remove(service);
			await context.SaveChangesAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int Id)
        {

            var query = from s in context.Services
                        where s.ServiceId == Id
                        select s;
            Service? service = query.FirstOrDefault();
            return service;
        }

        /// <summary>
        /// List and searching Services with pagination
        /// </summary>
        /// <param name="request"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public async Task<List<ServicesVM>> PagingServicesAsync(ServicePagingRequest request, string UserName)
		{
			// 1. Select all service of current user
			var query = from s in context.Services
						join u in context.AppUsers on s.UserId equals u.Id
						join sub in context.SubCategories on s.SubCategoryId equals sub.SubCateId
						join ur in context.UserRoles on u.Id equals ur.UserId
						join ro in context.AppRoles on ur.RoleId equals ro.Id
						where u.UserName.Equals(UserName)
						select new { s, sub, u, ro };

			// 2. search
			if (!string.IsNullOrEmpty(request.searchTerm))
			{
				query = query.Where(x => x.s.ServiceTitle.Contains(request.searchTerm));
			}

			//3. filter
			var data = query.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize)
				.Select(x => new ServicesVM()
				{
					ServiceId = x.s.ServiceId,
					ServiceTitle = x.s.ServiceTitle,
					isServiceActive = x.s.isServiceActive,
					ServiceIntro= x.s.ServiceIntro,
					ServiceImage= x.s.ServiceImage,
					ProviderFirstName = x.u.FirstName,
					ProviderLastName= x.u.LastName,
					SubCategoryId = x.s.SubCategoryId,
					SubCateName = x.sub.SubcateName,
					TotalClients= (x.s.TotalClients == null)?0:x.s.TotalClients,
					TotalStars= (x.s.TotalStars == null)?0:x.s.TotalStars
				});
			return await data.ToListAsync();
		}

        public async Task<string> SaveServiceImage(IFormFile? serviceImg)
        {
            if (serviceImg != null && serviceImg.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(serviceImg.FileName)}";
                var filePath = Path.Combine("wwwroot", "assets/images/services", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await serviceImg.CopyToAsync(fileStream);
                }

                return $"assets/images/services/{fileName}";
            }
            return null;
        }

        public async Task UpdateServiceAsync(Service newService)
        {
            Service currentService = await GetServiceByIdAsync(newService.ServiceId);
			if (currentService != null)
			{
				context.Services.Update(currentService);
                await context.SaveChangesAsync();
            }

        }
    }
}
