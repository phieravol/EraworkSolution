using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.PakageViewModel.Provider;
using ViewModels.ServiceViewModel;

namespace AppModules.Pakages.Provider
{
	public interface IManagePakages
	{
		Task CreatePakageAsync(PakageCreateRequest createRequest);
		List<Pakage>? GetPakagesService(int serviceId);
		Task<List<ServicesVM>> GetServicesUser(AppUser? user);
		Task UpdatePakage(PakageUpdateRequest updateRequest);
        Task<Pakage> GetPakageByIdAsync(int pakageId);
        Task DeletePagageAsync(int PakageId);
    }
}
