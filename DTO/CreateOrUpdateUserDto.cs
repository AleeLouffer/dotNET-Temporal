namespace dotNET_Temporal.DTO;

public class CreateOrUpdateUserDto
{
    public string Name { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
}
