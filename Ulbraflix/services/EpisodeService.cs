using Ulbraflix.domain.entities;
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

    public bool Insert(Episode entity)
    {
        return _episodeRepository.Insert(entity);
    }

    public bool Update(Episode entity)
    {
        return _episodeRepository.Update(entity);
    }

    public bool Delete(int id)
    {
        Episode episode = GetById(id);
        return _episodeRepository.Delete(episode);
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