using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface IWatchHistoryRepository : IBaseRepository<WatchHistory>, IBaseAsyncRepository<WatchHistory>
{
    
}