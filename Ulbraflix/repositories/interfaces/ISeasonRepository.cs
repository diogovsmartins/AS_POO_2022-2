using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface ISeasonRepository :IBaseRepository<Season>, IBaseAsyncRepository<Season>
{
    
}