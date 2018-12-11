using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Interfaces
{
    public interface IPost
    {
        Task<IEnumerable<Post>> GetAllPosts();

        Task<Post> GetPost(int? id);

        Task CreatePost(Post post);

        Task UpdatePost(Post post);

        Task DeletePost(int id);
    }
}
