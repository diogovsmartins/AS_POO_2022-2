namespace Ulbraflix.entities;

public class Serie : Title
{
    public Dictionary<int, SerieEpisode> SeriesEpisodes { get; set; }
}