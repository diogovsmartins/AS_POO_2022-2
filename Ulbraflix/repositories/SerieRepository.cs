using System.Linq;
using Ulbraflix.data.context;
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
        return _dataContext.Serie.SingleOrDefault(serie => serie.Id == id);
    }

    public List<Serie> GetAll()
    {
        return _dataContext.Serie.ToList();
    }

    public bool Insert(Serie entity)
    {
        if (entity.Equals(null) ||
            entity.Name.Equals(String.Empty) ||
            entity.Sinopsis.Equals(String.Empty) ||
            entity.Categories.Count==0) throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.Serie.Add(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Update(Serie entity)
    {
        if (entity.Equals(null) ||
            entity.Name.Equals(String.Empty) ||
            entity.Sinopsis.Equals(String.Empty) ||
            entity.Categories.Count==0) throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.Serie.Update(entity);
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
            Serie serie = GetById(id);
            _dataContext.Serie.Remove(serie);
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