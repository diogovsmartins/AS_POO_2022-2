using System.Collections.Generic;
using System.Linq;
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
        return _dataContext.Episode.SingleOrDefault(Episode => Episode.Id == id);
    }

    public List<Episode> GetAll()
    {
        return _dataContext.Episode.ToList();
    }

    public void Insert(Episode entity)
    {
        _dataContext.Episode.Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(Episode entity)
    {
        _dataContext.Episode.Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        Episode Episode = GetById(id);
        _dataContext.Episode.Remove(Episode);
        _dataContext.SaveChangesAsync();
    }
}