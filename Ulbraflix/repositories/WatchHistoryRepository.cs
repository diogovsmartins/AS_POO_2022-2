using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
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
        return _dataContext
            .WatchHistory
            .Include(watchHistory => watchHistory.Titles)
            .SingleOrDefault(watchHistory => watchHistory.Id == id);
    }

    public List<WatchHistory> GetAll()
    {
        return _dataContext
            .WatchHistory
            .Include(watchHistory => watchHistory.Titles)
            .ToList();
    }

    public bool Insert(WatchHistory entity)
    {
        _dataContext
            .WatchHistory
            .Add(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Update(WatchHistory entity)
    {
        _dataContext.WatchHistory.Update(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Delete(WatchHistory watchHistory)
    {
        _dataContext.WatchHistory.Remove(watchHistory);
        return (_dataContext.SaveChanges()) > 0;
    }

    public async Task<WatchHistory> GetByIdAsync(int id)
    {
        return await _dataContext
            .WatchHistory
            .Include(watchHistory => watchHistory.Titles)
            .FirstOrDefaultAsync(watchHistory => watchHistory.Id == id);
    }

    public async Task<IList<WatchHistory>> GetAllAsync()
    {
        return await _dataContext
            .WatchHistory
            .Include(watchHistory => watchHistory.Titles)
            .ToListAsync();
    }
}