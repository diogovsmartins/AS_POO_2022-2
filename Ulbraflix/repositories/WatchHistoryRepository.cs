using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
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
        return _dataContext.WatchHistory.SingleOrDefault(watchHistory => watchHistory.Id == id);
    }

    public List<WatchHistory> GetAll()
    {
        return _dataContext.WatchHistory.ToList();
    }

    public void Insert(WatchHistory entity)
    {
        _dataContext.WatchHistory.Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(WatchHistory entity)
    {
        _dataContext.WatchHistory.Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        WatchHistory watchHistory = GetById(id);
        _dataContext.WatchHistory.Remove(watchHistory);
        _dataContext.SaveChangesAsync();
    }

    public async Task<WatchHistory> GetByIdAsync(int id)
    {
        return await _dataContext
            .WatchHistory
            .FirstOrDefaultAsync(watchHistory => watchHistory.Id == id);
    }

    public async Task<IList<WatchHistory>> GetAllByIdAsync()
    {
        return await _dataContext
            .WatchHistory
            .ToListAsync();
    }
}