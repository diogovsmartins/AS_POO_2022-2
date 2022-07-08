using Ulbraflix.entities;
using Ulbraflix.repositories;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class UserProfileService : IBaseService<UserProfile>, IBaseAsyncService<UserProfile>
{

    private readonly UserProfileRepository _userProfileRepository;

    public UserProfileService(UserProfileRepository userProfileRepository)
    {
        this._userProfileRepository = userProfileRepository;
    }
    
    public UserProfile GetById(int id)
    {
        return _userProfileRepository.GetById(id);
    }

    public List<UserProfile> GetAll()
    {
        return _userProfileRepository.GetAll();
    }

    public void Insert(UserProfile entity)
    {
        _userProfileRepository.Insert(entity);
    }

    public void Update(UserProfile entity)
    {
        _userProfileRepository.Update(entity);
    }

    public void Delete(int id)
    {
        _userProfileRepository.Delete(id);
    }

    public async Task<UserProfile> GetByIdAsync(int id)
    {
        return await _userProfileRepository.GetByIdAsync(id);
    }

    public async Task<IList<UserProfile>> GetAllAsync()
    {
        return await _userProfileRepository.GetAllAsync();
    }
}