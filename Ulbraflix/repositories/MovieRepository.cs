using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class MovieRepository : IMovieRepository
{
    private DataContext _dataContext;

    public MovieRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public Movie GetById(int id)
    {
        return _dataContext.Movie.SingleOrDefault(movie => movie.id = id);
    }

    public List<Movie> GetAll()
    {
        return _dataContext.Movie.ToList();
    }

    public void Insert(Movie entity)
    {
        _dataContext.Movie.Add(entity);
    }

    public void Update(Movie entity)
    {
        _dataContext.Movie.Update(entity);
    }

    public void Delete(int id)
    {
        Movie movie = GetById(id);
        _dataContext.Movie.Remove(movie);
    }
}