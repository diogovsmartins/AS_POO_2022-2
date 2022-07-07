using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        return _dataContext.Rating.SingleOrDefault(rating => rating.Id == id);
    }

    public List<Rating> GetAll()
    {
        return _dataContext.Rating.ToList();
    }

    public void Insert(Rating entity)
    {
        _dataContext.Rating.Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(Rating entity)
    {
        _dataContext.Rating.Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        Rating rating = GetById(id);
        _dataContext.Rating.Remove(rating);
        _dataContext.SaveChangesAsync();
    }

    public async Task<Rating> GetByIdAsync(int id)
    {
        return await _dataContext
            .Rating
            .FirstOrDefaultAsync(rating => rating.Id == id);
    }

    public async Task<IList<Rating>> GetAllByIdAsync()
    {
        return await _dataContext
            .Rating
            .ToListAsync();
    }
}