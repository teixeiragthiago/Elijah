using Elijah.Domain.Common.Enums;

namespace Elijah.Application.DTOs.User;

public class UserDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public UserEnum.Profile Profile { get; set; }
    public UserEnum.Status Status { get; set; }
    public string? Password { get; set; }
    public string? Image { get; set; }
    public string? ImageFormat { get; set; }
    public DateTime DateRegister { get; set; }
}