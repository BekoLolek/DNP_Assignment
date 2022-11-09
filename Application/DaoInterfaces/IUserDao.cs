using Model;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    Task<User?> GetByIdAsync(int dtoOwnerId);

    Task<User> Register(User user);
    Task<User> Login(User user);
    Task<User> LogOut(User user);
}