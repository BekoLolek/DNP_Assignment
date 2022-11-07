namespace Model.DTOs;

public class UserCreationDto
{
    public int Id { get; set; }
    public string UserName { get; set; }

    public UserCreationDto(int id, string userName)
    {
        Id = id;
        UserName = userName;
    }
}