using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class WatchHistoryService : IWatchHistoryService
{
    private readonly IWatchHistoryRepository _watchHistoryRepository;

    public WatchHistoryService(IWatchHistoryRepository watchHistoryRepository)
    {
        this._watchHistoryRepository = watchHistoryRepository;
    }

    public WatchHistory GetById(int id)
    {
        return _watchHistoryRepository.GetById(id);
    }

    public List<WatchHistory> GetAll()
    {
        return _watchHistoryRepository.GetAll();
    }

    public void Insert(WatchHistory entity)
    {
        _watchHistoryRepository.Insert(entity);
    }

    public void Update(WatchHistory entity)
    {
        _watchHistoryRepository.Update(entity);
    }

    public void Delete(int id)
    {
        _watchHistoryRepository.Delete(id);
    }

    public async Task<WatchHistory> GetByIdAsync(int id)
    {
        return await _watchHistoryRepository.GetByIdAsync(id);
    }

    public async Task<IList<WatchHistory>> GetAllAsync()
    {
        return await _watchHistoryRepository.GetAllAsync();
    }
}