using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Model;
using Model.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.Owner.Id);
        if (user == null)
        {
            throw new Exception($"User with id {dto.Owner.Id} was not found.");
        }

        ValidateTodo(dto);
        Post post = new Post(user, dto.Title, dto.Body);
        Post created = await postDao.CreateAsync(post);
        return created;
    }
    
    private void ValidateTodo(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        // other validation stuff
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        List<Post>? list = await postDao.GetAllPostsAsync();
        return list;
    }
}