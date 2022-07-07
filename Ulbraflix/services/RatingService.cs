using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class RatingService : IRatingService
{

    private readonly IRatingRepository _ratingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public Task<Rating> GetByIdAsync(int id)
    {
        return await _ratingRepository.GetById();
    }

    public Task<IList<Rating>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public void Insert(Rating entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Rating entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}