using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
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
        return _dataContext.Rating.SingleOrDefault(rating => rating.Id == id);
    }

    public List<Rating> GetAll()
    {
        return _dataContext.Rating.ToList();
    }

    public bool Insert(Rating entity)
    {
        _dataContext.Rating.Add(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Update(Rating entity)
    {
        _dataContext.Rating.Update(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Delete(Rating rating)
    {
        _dataContext.Rating.Remove(rating);
        return (_dataContext.SaveChanges()) > 0;
    }

    public async Task<Rating> GetByIdAsync(int id)
    {
        return await _dataContext
            .Rating
            .FirstOrDefaultAsync(rating => rating.Id == id);
    }

    public async Task<IList<Rating>> GetAllAsync()
    {
        return await _dataContext
            .Rating
            .ToListAsync();
    }
}