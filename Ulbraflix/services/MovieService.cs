using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class MovieService : IMovieService
{

    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        this._movieRepository = movieRepository;
    }
    
    public async Task<Movie> GetByIdAsync(int id)
    {
        return await _movieRepository.GetByIdAsync(id);
    }

    public async Task<IList<Movie>> GetAllAsync()
    {
        return await _movieRepository.GetAllAsync();
    }

    public Movie GetById(int id)
    {
        return _movieRepository.GetById(id);
    }

    public List<Movie> GetAll()
    {
        return _movieRepository.GetAll();
    }

    public void Insert(Movie entity)
    {
        _movieRepository.Insert(entity);
    }

    public void Update(Movie entity)
    {
        _movieRepository.Update(entity);
    }

    public void Delete(int id)
    {
        _movieRepository.Delete(id);
    }
}