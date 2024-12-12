using Elijah.Application.DTOs.User;
using Elijah.Domain.Entities.User;
using FluentResults;

namespace Elijah.Application.Interfaces.User;

public interface IUserService
{
    Task<Result<IEnumerable<UserDataDto>>> GetCurrentUserAsync(CancellationToken ct);
    Task<Result<UserDataDto>> GetByIdAsync(int id, CancellationToken ct);
    Task<Result<int>> CreateAsync(UserDto dto, CancellationToken ct);
    Task<Result> UpdateAsync(UserDto dto, CancellationToken ct);
    Task<Result<int>> DeleteAsync(int id, CancellationToken ct);
    Task<Result<bool>> PutPassword(NewPasswordDto password, CancellationToken ct);
}