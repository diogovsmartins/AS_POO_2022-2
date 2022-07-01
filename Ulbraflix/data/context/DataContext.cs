using Microsoft.EntityFrameworkCore;
using Ulbraflix.entities;

namespace Ulbraflix.data.context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Category> Category { get; set; }
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Rating> Rating { get; set; }
    public DbSet<Serie> Serie { get; set; }
    public DbSet<Subscription> Subscription { get; set; }
    public DbSet<SerieEpisode> SerieEpisode { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserProfile> UserProfile { get; set; }
    public DbSet<WatchHistory> WatchHistory { get; set; }
    
    
}