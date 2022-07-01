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

    public bool Insert(Rating entity)
    {
        if (entity.Equals(null) ||
            entity.RatingValue==0)
            throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.Rating.Add(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
        
    }

    public bool Update(Rating entity)
    {
        if (entity.Equals(null) ||
            entity.RatingValue==0)
            throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.Rating.Update(entity);
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
            var rating = GetById(id);
            _dataContext.Rating.Remove(rating);
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