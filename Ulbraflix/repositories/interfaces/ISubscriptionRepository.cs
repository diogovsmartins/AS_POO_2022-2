using Ulbraflix.Controllers;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface ISubscriptionRepository : IBaseRepository<Subscription>, IBaseAsyncRepository<Subscription>
{
    
}