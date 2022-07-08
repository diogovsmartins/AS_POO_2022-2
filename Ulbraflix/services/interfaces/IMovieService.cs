using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.services.interfaces;

public interface IMovieService : IBaseService<Movie>, IBaseAsyncService<Movie>
{
    
}