using System.Collections.Generic;
using Ulbraflix.domain.entities;

namespace Ulbraflix.domain.DTOs_e_VOs;

public record MovieRecord(
    string Name,
    string Sinopse,
    bool IsWatched,
    List<Category> Categories,
    Rating Rating,
    int Duration,
    int LastMinuteWatched);