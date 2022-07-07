using Ulbraflix.entities;
using Ulbraflix.repositories;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class MovieService : IMovieService
{

    private readonly IMovieRepository _movieRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MovieService(IMovieRepository movieRepository, IUnitOfWork _unitOfWork)
    {
        this._movieRepository = movieRepository;
        this._unitOfWork = _unitOfWork;
    }
    
    public async Task<Movie> GetByIdAsync(int id)
    {
        return await _movieRepository.GetById(id);
    }

    public Task<IList<Movie>> GetAllAsync()
    {
        return await _movieRepository.GetAll();
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