using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class RatingRepository : IRatingRepository
{
    private DataContext _dataContext;

    public RatingRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public RatingRepository GetById(int id)
    {
        return _dataContext.RatingRepository.SingleOrDefault(
            RatingRepository => RatingRepository.id = id);
    }

    public List<RatingRepository> GetAll()
    {
        return _dataContext.RatingRepository.ToList();
    }

    public void Insert(RatingRepository entity)
    {
        _dataContext.RatingRepository.Add(entity);
    }

    public void Update(RatingRepository entity)
    {
        _dataContext.RatingRepository.Update(entity);
    }

    public void Delete(int id)
    {
        RatingRepository RatingRepository = GetById(id);
        _dataContext.RatingRepository.Remove(RatingRepository);
    }
}