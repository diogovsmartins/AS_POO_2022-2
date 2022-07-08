using Ulbraflix.entities;
using Ulbraflix.repositories;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class EpisodeService : IEpisodeService
{
    private readonly IEpisodeRepository _episodeRepository;

    public EpisodeService(IEpisodeRepository episodeRepository)
    {
        this._episodeRepository = episodeRepository;
    }
    
    public Episode GetById(int id)
    {
        return _episodeRepository.GetById(id);
    }

    public List<Episode> GetAll()
    {
        return _episodeRepository.GetAll();
    }

    public void Insert(Episode entity)
    {
        _episodeRepository.Insert(entity);
    }

    public void Update(Episode entity)
    {
        _episodeRepository.Update(entity);
    }

    public void Delete(int id)
    {
        _episodeRepository.Delete(id);
    }

    public async Task<Episode> GetByIdAsync(int id)
    {
        return await _episodeRepository.GetByIdAsync(id);
    }

    public async Task<IList<Episode>> GetAllAsync()
    {
        return await _episodeRepository.GetAllAsync();
    }
}