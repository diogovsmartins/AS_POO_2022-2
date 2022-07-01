namespace Ulbraflix.entities;

public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public WatchHistory WatchHistory { get; set; }
}