using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class UserProfileService : IUserProfileService
{

    private readonly IUserProfileRepository _userProfileRepository;

    public UserProfileService(IUserProfileRepository userProfileRepository)
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

    public bool Insert(UserProfile entity)
    {
        return _userProfileRepository.Insert(entity);
    }

    public bool Update(UserProfile entity)
    {
        return _userProfileRepository.Update(entity);
    }

    public bool Delete(int id)
    {
        UserProfile userProfile = GetById(id);
        return _userProfileRepository.Delete(userProfile);
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