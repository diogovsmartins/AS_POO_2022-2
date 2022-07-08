using System.Collections.Generic;

namespace Ulbraflix.domain.entities;

public class WatchHistory
{
    public int Id { get; set; }
    public List<Title> Titles { get; set; }
}