using System.Collections.Generic;

namespace Ulbraflix.domain.entities;

public class Season
{
    public int Id { get; set; }
    public List<Episode> Episode { get; set; }
}