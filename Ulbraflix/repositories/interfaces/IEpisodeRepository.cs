using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface IEpisodeRepository : IBaseRepository<Episode>, IBaseAsyncRepository<Episode>
{
    
}