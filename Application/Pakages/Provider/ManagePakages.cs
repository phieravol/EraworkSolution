using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.PakageViewModel.Provider;
using ViewModels.ServiceViewModel;

namespace AppModules.Pakages.Provider
{
	public class ManagePakages : IManagePakages
	{
		private readonly EraWorkContext context;

		public ManagePakages(EraWorkContext context)
		{
			this.context = context;
		}

		public async Task CreatePakageAsync(PakageCreateRequest createRequest)
		{
			Pakage newPakage = new Pakage()
			{
				PakageName = createRequest.PakageName,
				isPakageAcive = createRequest.IsActive.Equals("on")?true:false,
				Price = createRequest.Price,
				DeliveryDays = createRequest.DeliveryDay,
				RevisionLimit= createRequest.RevisionLimit,
				ServiceId = createRequest.ServiceId 
			};
			await context.Pakages.AddAsync(newPakage);
			await context.SaveChangesAsync();
		}

		public List<Pakage>? GetPakagesService(int serviceId)
		{
			var query = from p in context.Pakages
						where p.ServiceId == serviceId
						select p;
			return query.ToList();
		}

		public async Task<List<ServicesVM>> GetServicesUser(AppUser? user)
		{
			//1. select all pakage of 
			var query = from s in context.Services
						join u in context.AppUsers on s.UserId equals u.Id
						where u.UserName.Equals(user.UserName)
						select new { s, u };

			var data = query.Select(x => new ServicesVM()
			{
				ServiceId= x.s.ServiceId,
				ServiceTitle = x.s.ServiceTitle,
				ServiceIntro= x.s.ServiceIntro,
				ServiceImage = x.s.ServiceImage,
				isServiceActive=x.s.isServiceActive,
				TotalStars= x.s.TotalStars,
				TotalClients= x.s.TotalClients,
				SubCategoryId= x.s.SubCategoryId,
				ProviderFirstName = user.FirstName,
				ProviderLastName = user.LastName,
				
			});

			return await data.ToListAsync();
		}

		public async Task UpdatePakage(PakageUpdateRequest updateRequest)
		{
			Pakage CurrentPakage = await GetPakageByIdAsync(updateRequest.PakageId);

			if (CurrentPakage != null)
			{
				CurrentPakage.PakageId = updateRequest.PakageId;
				CurrentPakage.PakageName = updateRequest.PakageName;
				CurrentPakage.isPakageAcive = (updateRequest.IsActive == "on" ? true : false);
				CurrentPakage.Price = updateRequest.Price;
				CurrentPakage.DeliveryDays = updateRequest.DeliveryDay;
				CurrentPakage.RevisionLimit = updateRequest.RevisionLimit;

				context.Pakages.Update(CurrentPakage);
				await context.SaveChangesAsync();
			}
	
		}

		public async Task<Pakage> GetPakageByIdAsync(int pakageId)
		{
			var query = from p in context.Pakages
						where p.PakageId == pakageId
						select p;
			var pakage = await query.FirstOrDefaultAsync();
			return pakage;
		}

        public async Task DeletePagageAsync(int PakageId)
        {
			Pakage pakage = await GetPakageByIdAsync(PakageId);
            context.Pakages.Remove(pakage);
			await context.SaveChangesAsync();
        }
    }
}
