using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface ISerieRepository : IBaseRepository<Serie>, IBaseAsyncRepository<Serie>
{
    
}