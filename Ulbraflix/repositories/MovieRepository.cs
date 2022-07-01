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

    public bool Insert(Movie entity)
    {
        if (entity.Equals(null) ||
            entity.Name.Equals(String.Empty) ||
            entity.Sinopsis.Equals(String.Empty) ||
            entity.Categories.Count==0) throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.Movie.Add(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Update(Movie entity)
    {
        if (entity.Equals(null) ||
            entity.Name.Equals(String.Empty) ||
            entity.Sinopsis.Equals(String.Empty) ||
            entity.Categories.Count==0) throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.Movie.Update(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Delete(int id)
    {
        bool success=true;
        try
        {
            Movie movie = GetById(id);
            _dataContext.Movie.Remove(movie);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }
}