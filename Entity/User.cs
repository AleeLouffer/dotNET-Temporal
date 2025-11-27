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

        Validate();
    }
    
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public ESituation SituationId { get; set; }
    public DateTime CreationDate { get; set; }

    internal void Validate()
    {
        if (string.IsNullOrWhiteSpace(Login)) throw new Exception("Login is null or empty, please insert Login to create a new user.");
        if (string.IsNullOrWhiteSpace(Password)) throw new Exception("Password is null or empty, please insert Password to create a new user.");
        if (string.IsNullOrWhiteSpace(Email)) throw new Exception("Email is null or empty, please insert Email to create a new user.");
        if (string.IsNullOrWhiteSpace(Name)) throw new Exception("Name is null or empty, please insert email to create a new user.");
        if (SituationId == 0) throw new Exception("Situation is empty");
        if (CreationDate == DateTime.MinValue) throw new Exception("Creation date is empty");
    }

    internal void Update(CreateOrUpdateUserDto dto)
    {
        Login = dto.Login;
        Password = dto.Password;
        Email = dto.Email;
        Name = dto.Name;

        Validate();
    }
}
