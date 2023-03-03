using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.PostViewModel;
using ViewModels.PostViewModel.Public;

namespace AppModules.Posts.Public
{
    public interface IPublicPost
	{
		Task<List<PostVM>> GetPostFilterPaging(PublicPostPagingRequest pagingRequest);
	}
}
