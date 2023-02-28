using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.PostViewModel;
using ViewModels.SubCatesViewModel.Public;

namespace AppModules.Posts.Public
{
	public class PublicPost : IPublicPost
	{
		public Task<List<PostVM>> GetPostFilterPaging(PublicPostPagingRequest pagingRequest, AppUser user)
		{
			throw new NotImplementedException();
		}
	}
}
