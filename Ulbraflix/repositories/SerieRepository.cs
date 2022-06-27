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
        return _dataContext.Serie.SingleOrDefault(Serie => Serie.id = id);
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
        Serie Serie = GetById(id);
        _dataContext.Serie.Remove(Serie);
    }
}