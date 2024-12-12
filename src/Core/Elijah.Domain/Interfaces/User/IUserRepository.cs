using Elijah.Domain.Entities.User;
using Elijah.Domain.Interfaces.Base;

namespace Elijah.Domain.Interfaces.User;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task PutPasswordAsync(int idUser, byte[] passwordHash, byte[] passwordSalt, CancellationToken ct);
    Task PutImagePathAsync(int idUser, string imagePath, CancellationToken ct);
}