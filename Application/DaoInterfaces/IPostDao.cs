using Model;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<List<Post>> GetAllPostsAsync();
}