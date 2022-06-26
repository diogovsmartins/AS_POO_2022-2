namespace Ulbraflix.Controllers;

public class UserRepository : IUserRepository
{
    private DataCOntext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public User GetById(int id)
    {
        return _dataContext.User.SingleOrDefault(user => user.id = id);
    }

    public List<User> GetAll()
    {
        return _dataContext.User.ToList();
    }

    public void Insert(User entity)
    {
        _dataContext.User.Add(entity);
    }

    public void Update(User entity)
    {
        _dataContext.User.Update(entity);
    }

    public void Delete(int id)
    {
        User user = GetById(id);
        _dataContext.User.Remove(user);
    }
}