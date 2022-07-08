using System.Collections.Generic;
using Ulbraflix.entities;
using Ulbraflix.entities.enums;

namespace Ulbraflix.domain.entities;

public class Subscription
{
    public int Id { get; set; }
    public SubscriptionEnum SubscriptionType { get; set; }
    public bool IsActive { get; set; }
    public string PaymentMethod { get; set; }
    public decimal PaymentValue { get; set; }
    public User User { get; set; }
    public List<UserProfile> UsersProfiles { get; set; }
}