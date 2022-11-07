namespace Model.DTOs;

public class PostCreationDto
{
    public int Id { get; set; }
    public User Owner { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public PostCreationDto(int id, User owner, string title, string body)
    {
        Id = id;
        Owner = owner;
        Title = title;
        Body = body;
    }
}