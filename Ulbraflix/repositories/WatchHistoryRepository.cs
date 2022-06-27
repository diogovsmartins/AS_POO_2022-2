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
        return _dataContext.WatchHistory.SingleOrDefault(WatchHistory => WatchHistory.id = id);
    }

    public List<WatchHistory> GetAll()
    {
        return _dataContext.WatchHistory.ToList();
    }

    public void Insert(WatchHistory entity)
    {
        _dataContext.WatchHistory.Add(entity);
    }

    public void Update(WatchHistory entity)
    {
        _dataContext.WatchHistory.Update(entity);
    }

    public void Delete(int id)
    {
        WatchHistory WatchHistory = GetById(id);
        _dataContext.WatchHistory.Remove(WatchHistory);
    }
}