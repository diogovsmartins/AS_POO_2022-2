using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class SeasonRepository : ISeasonRepository
{
    private DataContext _dataContext;

    public SeasonRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Season GetById(int id)
    {
        return _dataContext
            .Season
            .Include(season => season.Episode)
            .SingleOrDefault(season => season.Id == id);
    }

    public List<Season> GetAll()
    {
        return _dataContext
            .Season
            .Include(season => season.Episode)
            .ToList();
    }

    public void Insert(Season entity)
    {
        _dataContext.Season.Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(Season entity)
    {
        _dataContext.Season.Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        Season season = GetById(id);
        _dataContext.Season.Remove(season);
        _dataContext.SaveChangesAsync();
    }

    public async Task<Season> GetByIdAsync(int id)
    {
        return await _dataContext
            .Season
            .Include(season => season.Episode)
            .FirstOrDefaultAsync(season => season.Id == id);
    }

    public async Task<IList<Season>> GetAllAsync()
    {
        return await _dataContext
            .Season
            .Include(season => season.Episode)
            .ToListAsync();
    }
}