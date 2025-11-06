using dotNET_Temporal.DTO;
using dotNET_Temporal.Util.Enums;

namespace dotNET_Temporal.Entity;

public class User
{
    public User() { }

    public User(CreateOrUpdateUserDto dto)
    {
        Login = dto.Login;
        Password = dto.Password;
        Email = dto.Email;
        Name = dto.Name;
        SituationId = ESituation.Active;
        CreationDate = DateTime.Now;
    }
    
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public ESituation SituationId { get; set; }
    public DateTime CreationDate { get; set; }

    internal void Update(CreateOrUpdateUserDto dto)
    {
        Login = dto.Login;
        Password = dto.Password;
        Email = dto.Email;
        Name = dto.Name;
    }
}
