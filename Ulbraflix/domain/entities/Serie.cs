using System.Collections.Generic;
using Ulbraflix.entities;

namespace Ulbraflix.domain.entities;

public class Serie : Title
{
    public List<Season> Seasons { get; set; }
}