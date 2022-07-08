using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository _subscriptionRepository)
    {
        this._subscriptionRepository = _subscriptionRepository;
    }

    public Subscription GetById(int id)
    {
        return _subscriptionRepository.GetById(id);
    }

    public List<Subscription> GetAll()
    {
        return _subscriptionRepository.GetAll();
    }

    public bool Insert(Subscription entity)
    {
        return _subscriptionRepository.Insert(entity);
    }

    public bool Update(Subscription entity)
    {
        return _subscriptionRepository.Update(entity);
    }

    public bool Delete(int id)
    {
        Subscription subscription = GetById(id);
        return _subscriptionRepository.Delete(subscription);
    }

    public async Task<Subscription> GetByIdAsync(int id)
    {
        return await _subscriptionRepository.GetByIdAsync(id);
    }

    public async Task<IList<Subscription>> GetAllAsync()
    {
        return await _subscriptionRepository.GetAllAsync();
    }
}