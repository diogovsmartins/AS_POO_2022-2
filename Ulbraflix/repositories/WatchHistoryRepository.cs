using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class WatchHistoryRepository : IWatchHistoryRepository
{
    private DataContext _dataContext;

    public WatchHistoryRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public WatchHistory GetById(int id)
    {
        return _dataContext.WatchHistory.SingleOrDefault(watchHistory => watchHistory.id = id);
    }

    public List<WatchHistory> GetAll()
    {
        return _dataContext.WatchHistory.ToList();
    }

    public bool Insert(WatchHistory entity)
    {
        if (entity.Equals(null) ||
            entity.Titles.Count==0)
            throw new ArgumentException();
        bool success=true;
        try
        {        
            _dataContext.WatchHistory.Add(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Update(WatchHistory entity)
    {
        if (entity.Equals(null) ||
            entity.Titles.Count==0)
            throw new ArgumentException();
        bool success=true;
        try
        {        
            _dataContext.WatchHistory.Update(entity);
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
            WatchHistory watchHistory = GetById(id);
            _dataContext.WatchHistory.Remove(watchHistory);
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