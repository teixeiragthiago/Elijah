using Elijah.Domain.Entities.User;
using Elijah.Domain.Interfaces.Base;

namespace Elijah.Domain.Interfaces.User;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task PutPassword(int idUser, byte[] passwordHash, byte[] passwordSalt);
    Task PutImagePath(int idUser, string imagePath);
}