using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class EpisodeRepository : IEpisodeRepository
{
    private DataContext _dataContext;

    public EpisodeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Episode GetById(int id)
    {
        return _dataContext
            .Episode
            .SingleOrDefault(Episode => Episode.Id == id);
    }

    public List<Episode> GetAll()
    {
        return _dataContext.Episode.ToList();
    }

    public bool Insert(Episode entity)
    {
        _dataContext.Episode.Add(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Update(Episode entity)
    {
        _dataContext.Episode.Update(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Delete(Episode episode)
    {
        _dataContext.Episode.Remove(episode);
        return (_dataContext.SaveChanges()) > 0;
    }

    public async Task<Episode> GetByIdAsync(int id)
    {
        return await _dataContext
            .Episode
            .FirstOrDefaultAsync(episode => episode.Id == id);
    }

    public async Task<IList<Episode>> GetAllAsync()
    {
        return await _dataContext
            .Episode
            .ToListAsync();
    }
}