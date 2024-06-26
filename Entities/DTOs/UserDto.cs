namespace Entities.DTOs;

public record UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Address { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}