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

    public bool Insert(SerieEpisode entity)
    {
        if (entity.Equals(null)||
            entity.Duration == 0 ||
            entity.Sinopsis.Equals(String.Empty))
            throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.SerieEpisode.Add(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Update(SerieEpisode entity)
    {
        if (entity.Equals(null)||
            entity.Duration == 0 ||
            entity.Sinopsis.Equals(String.Empty))
            throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.SerieEpisode.Update(entity);
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
            SerieEpisode serieEpisode = GetById(id);
            _dataContext.SerieEpisode.Remove(serieEpisode);
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