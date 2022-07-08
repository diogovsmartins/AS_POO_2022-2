using System.Collections.Generic;
using Ulbraflix.domain.entities;
using Ulbraflix.entities.enums;

namespace Ulbraflix.domain.DTOs_e_VOs;

public record SubscriptionRecord(
    SubscriptionEnum SubscriptionEnum,
    bool IsActive,
    string PaymentMethod,
    decimal PaymentValue,
    User User,
    List<UserProfile> UserProfiles
    );
