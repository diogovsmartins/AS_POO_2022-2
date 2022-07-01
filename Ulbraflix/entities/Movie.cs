namespace Ulbraflix.entities;

public class Movie : Title
{
    public int Duration { get; set; }
    public int LastMinuteWatched { get; set; }
}