using Ulbraflix.data.context;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class EpisodeRepository : ISerieEpisodeRepository
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
    }

    public void Update(Episode entity)
    {
        _dataContext.Episode.Update(entity);
    }

    public void Delete(int id)
    {
        Episode Episode = GetById(id);
        _dataContext.Episode.Remove(Episode);
    }
}