using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class SerieService : ISerieService
{
    private readonly ISerieRepository _serieRepository;

    public SerieService(ISerieRepository _serieRepository)
    {
        this._serieRepository = _serieRepository;
    }
    
    public Serie GetById(int id)
    {
        return _serieRepository.GetById(id);
    }

    public List<Serie> GetAll()
    {
        return _serieRepository.GetAll();
    }

    public bool Insert(Serie entity)
    {
        return _serieRepository.Insert(entity);
    }

    public bool Update(Serie entity)
    {
        return _serieRepository.Update(entity);
    }

    public bool Delete(int id)
    {
        Serie serie = GetById(id);
        return _serieRepository.Delete(serie);
    }

    public async Task<Serie> GetByIdAsync(int id)
    {
        return await _serieRepository.GetByIdAsync(id);
    }

    public async Task<IList<Serie>> GetAllAsync()
    {
        return await _serieRepository.GetAllAsync();
    }
}