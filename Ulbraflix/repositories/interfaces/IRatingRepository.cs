using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface IRatingRepository : IBaseRepository<Rating>, IBaseAsyncRepository<Rating>
{
    
}