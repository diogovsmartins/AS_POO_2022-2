using System.Linq;
using Ulbraflix.data.context;
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

    public bool Insert(Subscription entity)
    {
        if (entity.Equals(null) ||
            entity.User.Equals(null) ||
            entity.PaymentMethod.Equals(String.Empty) ||
            entity.PaymentValue==0 ||
            entity.SubscriptionType.Equals(null)) throw new ArgumentException();
        bool success=true;
        try
        {
            entity.IsActive = true;
            _dataContext.Subscription.Add(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Update(Subscription entity)
    {
        if (entity.Equals(null) ||
            entity.User.Equals(null) ||
            entity.PaymentMethod.Equals(String.Empty) ||
            entity.PaymentValue==0 ||
            entity.SubscriptionType.Equals(null)) throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.Subscription.Update(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Delete(int id)
    {
        bool success=true;
        try
        {
            Subscription subscription = GetById(id);
            _dataContext.Subscription.Remove(subscription);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }
}