using System.Collections.Generic;
using Ulbraflix.domain.entities;
using Ulbraflix.entities.enums;

namespace Ulbraflix.domain.DTOs_e_VOs;

public record SubscriptionRecordVO(
    SubscriptionEnum SubscriptionEnum,
    bool IsActive,
    string PaymentMethod,
    decimal PaymentValue,
    User User,
    List<UserProfile> UserProfiles
    );
