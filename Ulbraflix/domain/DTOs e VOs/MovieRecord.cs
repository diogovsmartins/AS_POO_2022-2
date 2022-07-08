using System.Collections.Generic;
using Ulbraflix.domain.entities;

namespace Ulbraflix.domain.DTOs_e_VOs;

public record MovieRecord(
    int Id,
    string Name,
    string Sinopsis,
    bool IsWatched,
    List<Category> Categories,
    Rating Rating,
    int Duration,
    int LastMinuteWatched);