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

    public void Insert(Movie entity)
    {
        _dataContext.Movie.Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(Movie entity)
    {
        _dataContext.Movie.Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        Movie movie = GetById(id);
        _dataContext.Movie.Remove(movie);
        _dataContext.SaveChangesAsync();
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