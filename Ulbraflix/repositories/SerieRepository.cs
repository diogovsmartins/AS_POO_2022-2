using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class SerieRepository : ISerieRepository
{
    private DataContext _dataContext;

    public SerieRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Serie GetById(int id)
    {
        return _dataContext
            .Serie
            .Include(serie => serie.Season)
            .Include(serie => serie.Categories)
            .Include(serie => serie.Rating)
            .SingleOrDefault(serie => serie.Id == id);
    }

    public List<Serie> GetAll()
    {
        return _dataContext
            .Serie
            .Include(serie => serie.Season)
            .Include(serie => serie.Categories)
            .Include(serie => serie.Rating)
            .ToList();
    }

    public void Insert(Serie entity)
    {
        _dataContext.Serie.Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(Serie entity)
    {
        _dataContext.Serie.Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        Serie serie = GetById(id);
        _dataContext.Serie.Remove(serie);
        _dataContext.SaveChangesAsync();
    }

    public async Task<Serie> GetByIdAsync(int id)
    {
        return await _dataContext
            .Serie
            .Include(serie => serie.Season)
            .Include(serie => serie.Categories)
            .Include(serie => serie.Rating)
            .FirstOrDefaultAsync(serie => serie.Id == id);
    }

    public async Task<IList<Serie>> GetAllAsync()
    {
        return await _dataContext
            .Serie
            .Include(serie => serie.Season)
            .Include(serie => serie.Categories)
            .Include(serie => serie.Rating)
            .ToListAsync();
    }
}