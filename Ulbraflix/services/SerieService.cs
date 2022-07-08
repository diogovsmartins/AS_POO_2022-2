using Ulbraflix.entities;
using Ulbraflix.repositories;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class SerieService : IBaseService<Serie>, IBaseAsyncService<Serie>
{
    private readonly SerieRepository _serieRepository;

    public SerieService(SerieRepository _serieRepository)
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

    public void Insert(Serie entity)
    {
        _serieRepository.Insert(entity);
    }

    public void Update(Serie entity)
    {
        _serieRepository.Update(entity);
    }

    public void Delete(int id)
    {
        _serieRepository.Delete(id);
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