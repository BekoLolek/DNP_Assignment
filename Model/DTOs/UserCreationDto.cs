namespace Model.DTOs;

public class UserCreationDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public UserCreationDto(int id, string userName, string password)
    {
        Id = id;
        UserName = userName;
        Password = password;
    }
}