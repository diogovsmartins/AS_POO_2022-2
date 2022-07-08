using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class SeasonService : ISeasonService
{

    private readonly ISeasonRepository _seasonRepository;

    public SeasonService(ISeasonRepository _seasonRepository)
    {
        this._seasonRepository = _seasonRepository;
    }
    
    public Season GetById(int id)
    {
        return _seasonRepository.GetById(id);
    }

    public List<Season> GetAll()
    {
        return _seasonRepository.GetAll();
    }

    public bool Insert(Season entity)
    {
        return _seasonRepository.Insert(entity);
    }

    public bool Update(Season entity)
    {
        return _seasonRepository.Update(entity);
    }

    public bool Delete(int id)
    {
        Season season = GetById(id);
        return _seasonRepository.Delete(season);
    }

    public async Task<Season> GetByIdAsync(int id)
    {
        return await _seasonRepository.GetByIdAsync(id);
    }

    public async Task<IList<Season>> GetAllAsync()
    {
        return await _seasonRepository.GetAllAsync();
    }
}