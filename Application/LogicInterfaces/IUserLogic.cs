using Model;
using Model.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto dto);
    
    Task<User> Register(User user);
    Task<User> Login(User user);
    Task<User> LogOut(User user);
}