using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public User GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public List<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    public void Insert(User entity)
    {
        _userRepository.Insert(entity);
    }

    public void Update(User entity, int id)
    {
        User user=GetById(id);
        user.Email = entity.Email;
        user.Password = entity.Password;
        _userRepository.Update(user);
    }

    public void Delete(int id)
    {
        User user=GetById(id);
        _userRepository.Delete(user);
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<IList<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }
}