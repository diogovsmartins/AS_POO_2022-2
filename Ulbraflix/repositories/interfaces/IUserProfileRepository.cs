using Ulbraflix.Controllers;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface IUserProfileRepository : IBaseRepository<UserProfile>, IBaseAsyncRepository<UserProfile>
{
    
}