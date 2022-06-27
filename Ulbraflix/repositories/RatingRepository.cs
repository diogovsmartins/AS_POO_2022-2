using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class Rating : IRatingRepository

{
    private DataContext _dataContext;

    public Rating(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Rating GetById(int id)
    {
        return _dataContext.Rating.SingleOrDefault(Rating => Rating.id = id);
    }

    public List<Rating> GetAll()
    {
        return _dataContext.Rating.ToList();
    }

    public void Insert(Rating entity)
    {
        _dataContext.Rating.Add(entity);
    }

    public void Update(Rating entity)
    {
        _dataContext.Rating.Update(entity);
    }

    public void Delete(int id)
    {
        var Rating = GetById(id);
        _dataContext.Rating.Remove(Rating);
    }
}