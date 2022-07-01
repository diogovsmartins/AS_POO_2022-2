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
        return _dataContext.Serie.SingleOrDefault(serie => serie.id = id);
    }

    public List<Serie> GetAll()
    {
        return _dataContext.Serie.ToList();
    }

    public void Insert(Serie entity)
    {
        _dataContext.Serie.Add(entity);
    }

    public void Update(Serie entity)
    {
        _dataContext.Serie.Update(entity);
    }

    public void Delete(int id)
    {
        Serie serie = GetById(id);
        _dataContext.Serie.Remove(serie);
    }
}