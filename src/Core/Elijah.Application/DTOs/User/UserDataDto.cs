using System.ComponentModel.DataAnnotations.Schema;
using Elijah.Domain.Common.Enums;

namespace Elijah.Application.DTOs.User;

public class UserDataDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public UserEnum.Profile Profile { get; set; }
    public UserEnum.Status Status { get; set; }
    public DateTime DateRegister { get; set; }
    public string? Image { get; set; }

    [NotMapped]
    public string ProfileName => Profile.ToString();
}