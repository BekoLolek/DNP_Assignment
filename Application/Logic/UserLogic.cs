using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Model;
using Model.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }


    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            UserName = dto.UserName
        };
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }
    
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }

    public async Task<User> Register(User user)
    {
        User registered = await userDao.Register(user);
        return registered;
    }

    public async Task<User> Login(User user)
    {
        User loggedIn = await userDao.Login(user);
        return loggedIn;
    }

    public async Task<User> LogOut(User user)
    {
        User loggedOut = await userDao.LogOut(user);
        return loggedOut;
    }
}