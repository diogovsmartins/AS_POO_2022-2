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

    public void Insert(Season entity)
    {
        _seasonRepository.Insert(entity);
    }

    public void Update(Season entity)
    {
        _seasonRepository.Update(entity);
    }

    public void Delete(int id)
    {
        _seasonRepository.Delete(id);
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