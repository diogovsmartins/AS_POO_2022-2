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

    public async Task<Movie> GetByIdAsync(int id)
    {
        return await _dataContext
            .DbSetMovie
            .FirstOrDefault(movie => movie.Id == id);
    }

    public async Task<IList<Movie>> GetAllByIdAsync()
    {
        return await _dataContext
            .DbSetMovie
            .ToListAsync();
    }
}