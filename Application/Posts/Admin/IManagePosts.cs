using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.PostViewModel;
using ViewModels.PostViewModel.Admin;

namespace AppModules.Posts.Admin
{
	public interface IManagePosts
	{
        Task CreatePostAsync(PostCreateRequest createRequest, AppUser user);
		Task DeletePostAsync(int postId);
		Task<Post> GetPostByIdAsync(int? id);
		Task<List<PostVM>> GetPostPagingAsync(PagingPostRequest request, AppUser User);
        Task UpdatePostAsync(Post currentPost, AppUser user);
    }
}
