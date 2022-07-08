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

    public void Insert(Subscription entity)
    {
        _subscriptionRepository.Insert(entity);
    }

    public void Update(Subscription entity)
    {
        _subscriptionRepository.Update(entity);
    }

    public void Delete(int id)
    {
        _subscriptionRepository.Delete(id);
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