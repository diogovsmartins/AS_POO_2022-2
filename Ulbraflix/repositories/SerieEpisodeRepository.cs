using Ulbraflix.data.context;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class SerieEpisodeRepository : ISerieEpisodeRepository
{
    private DataContext _dataContext;

    public SerieEpisodeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public SerieEpisode GetById(int id)
    {
        return _dataContext.SerieEpisode.SingleOrDefault(serieEpisode => serieEpisode.id = id);
    }

    public List<SerieEpisode> GetAll()
    {
        return _dataContext.SerieEpisode.ToList();
    }

    public void Insert(SerieEpisode entity)
    {
        _dataContext.SerieEpisode.Add(entity);
    }

    public void Update(SerieEpisode entity)
    {
        _dataContext.SerieEpisode.Update(entity);
    }

    public void Delete(int id)
    {
        SerieEpisode serieEpisode = GetById(id);
        _dataContext.SerieEpisode.Remove(serieEpisode);
    }
}