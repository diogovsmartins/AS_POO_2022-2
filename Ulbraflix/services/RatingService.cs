using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class RatingService : IRatingService
{

    private readonly IRatingRepository _ratingRepository;

    public RatingService(IRatingRepository ratingRepository)
    {
        this._ratingRepository = ratingRepository;
    }

    public async Task<Rating> GetByIdAsync(int id)
    {
        return await _ratingRepository.GetByIdAsync(id);
    }

    public async Task<IList<Rating>> GetAllAsync()
    {
        return await _ratingRepository.GetAllAsync();
    }

    public Rating GetById(int id)
    {
        return _ratingRepository.GetById(id);
    }

    public List<Rating> GetAll()
    {
        return _ratingRepository.GetAll();
    }

    public bool Insert(Rating entity)
    {
        return _ratingRepository.Insert(entity);
    }

    public bool Update(Rating entity)
    {
        return _ratingRepository.Update(entity);
    }

    public bool Delete(int id)
    {
        Rating rating = GetById(id);
        return _ratingRepository.Delete(rating);
    }
}