using System.Collections.Generic;
using System.Linq;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;
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
        return _dataContext.Subscription.SingleOrDefault(subscription => subscription.Id == id);
    }

    public List<Subscription> GetAll()
    {
        return _dataContext.Subscription.ToList();
    }

    public void Insert(Subscription entity)
    {
        entity.IsActive = true;
        _dataContext.Subscription.Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(Subscription entity)
    {
        _dataContext.Subscription.Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        Subscription subscription = GetById(id);
        _dataContext.Subscription.Remove(subscription);
        _dataContext.SaveChangesAsync();
    }
}