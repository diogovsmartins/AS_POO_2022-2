using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private DataContext _dataContext;

    public SubscriptionRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public Subscription GetById(int id)
    {
        return _dataContext.Subscription.SingleOrDefault(subscription => subscription.id = id);
    }

    public List<Subscription> GetAll()
    {
        return _dataContext.Subscription.ToList();
    }

    public void Insert(Subscription entity)
    {
        _dataContext.Subscription.Add(entity);
    }

    public void Update(Subscription entity)
    {
        _dataContext.Subscription.Update(entity);
    }

    public void Delete(int id)
    {
        Subscription subscription = GetById(id);
        _dataContext.Subscription.Remove(subscription);
    }
}