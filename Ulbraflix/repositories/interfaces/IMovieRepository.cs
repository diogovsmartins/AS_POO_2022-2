using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface IMovieRepository : IBaseRepository<Movie>, IBaseAsyncRepository<Movie>
{
    
}