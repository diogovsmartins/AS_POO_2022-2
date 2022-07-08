using Microsoft.EntityFrameworkCore;
using Npgsql;
using Ulbraflix.data.mappings;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.entities.enums;

namespace Ulbraflix.data.context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<SubscriptionEnum>();
    }

    public DbSet<Category> Category { get; set; }
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Rating> Rating { get; set; }
    public DbSet<Serie> Serie { get; set; }
    public DbSet<Subscription> Subscription { get; set; }
    public DbSet<Episode> Episode { get; set; }
    public DbSet<Title> Title { get; set; }
    public DbSet<Season> Season { get; set; } 
    public DbSet<User> User { get; set; }
    public DbSet<UserProfile> UserProfile { get; set; }
    public DbSet<WatchHistory> WatchHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<SubscriptionEnum>();
        
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new MovieMap());
        modelBuilder.ApplyConfiguration(new RatingMap());
        modelBuilder.ApplyConfiguration(new SerieMap());
        modelBuilder.ApplyConfiguration(new SubscriptionMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new UserProfileMap());
        modelBuilder.ApplyConfiguration(new WatchHistoryMap());
        modelBuilder.ApplyConfiguration(new TitleMap());
        modelBuilder.ApplyConfiguration(new EpisodeMap());
        modelBuilder.ApplyConfiguration(new SeasonMap());
        
    }
}