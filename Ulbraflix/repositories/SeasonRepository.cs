using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
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

    public bool Insert(Season entity)
    {
        _dataContext.Season.Add(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Update(Season entity)
    {
        _dataContext.Season.Update(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Delete(Season season)
    {
        _dataContext.Season.Remove(season);
        return (_dataContext.SaveChanges()) > 0;
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