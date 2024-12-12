using Elijah.Domain.Entities.User;
using Elijah.Domain.Interfaces.User;
using Elijah.Infrastructure.Database.Context;
using Elijah.Infrastructure.Database.Repository.Base;

namespace Elijah.Infrastructure.Database.Repository.User;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context), IUserRepository
{
    public Task PutPasswordAsync(int idUser, byte[] passwordHash, byte[] passwordSalt, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task PutImagePathAsync(int idUser, string imagePath, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}