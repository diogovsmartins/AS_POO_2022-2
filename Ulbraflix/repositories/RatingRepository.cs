using System.Linq;
using Ulbraflix.data.context;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class RatingRepository : IRatingRepository

{
    private DataContext _dataContext;

    public RatingRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Rating GetById(int id)
    {
        return _dataContext.Rating.SingleOrDefault(rating => rating.id = id);
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
        var rating = GetById(id);
        _dataContext.Rating.Remove(rating);
    }
}