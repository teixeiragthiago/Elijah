using Elijah.Application.DTOs.User;
using Elijah.Application.Interfaces.User;
using Elijah.Domain.Interfaces.User;
using FluentResults;

namespace Elijah.Application.Services.User;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public Task<Result<IEnumerable<UserDataDto>>> GetCurrentUserAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<UserDataDto>> GetByIdAsync(int id, CancellationToken ct)
    {
        //Add cancellation token
        var user = await _userRepository.FirstAsync(x => x.Id == id, ct);
        
        throw new NotImplementedException();
    }

    public Task<Result<int>> CreateAsync(UserDto dto, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateAsync(UserDto dto, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result<int>> DeleteAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> PutPassword(NewPasswordDto password, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}