using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
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
        return _dataContext
            .Movie
            .Include(movie => movie.Categories)
            .Include(movie => movie.Rating)
            .SingleOrDefault(movie => movie.Id == id);
    }

    public List<Movie> GetAll()
    {
        return _dataContext
            .Movie
            .Include(movie => movie.Categories)
            .Include(movie => movie.Rating)
            .ToList();
    }

    public bool Insert(Movie entity)
    {
        _dataContext.Movie.Add(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Update(Movie entity)
    {
        _dataContext.Movie.Update(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Delete(Movie movie)
    {
        _dataContext.Movie.Remove(movie);
        return (_dataContext.SaveChanges()) > 0;
    }

    public async Task<Movie> GetByIdAsync(int id)
    {
        return await _dataContext
            .Movie
            .Include(movie => movie.Categories)
            .Include(movie => movie.Rating)
            .FirstOrDefaultAsync(movie => movie.Id == id);
    }

    public async Task<IList<Movie>> GetAllAsync()
    {
        return await _dataContext
            .Movie
            .Include(movie => movie.Categories)
            .Include(movie => movie.Rating)
            .ToListAsync();
    }
}