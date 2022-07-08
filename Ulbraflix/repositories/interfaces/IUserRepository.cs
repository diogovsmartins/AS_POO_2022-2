using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface IUserRepository : IBaseRepository<User>, IBaseAsyncRepository<User>
{
    
}