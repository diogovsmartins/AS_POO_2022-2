using Ulbraflix.Controllers;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface IWatchHistoryRepository : IBaseRepository<WatchHistory>, IBaseAsyncRepository<WatchHistory>
{
    
}