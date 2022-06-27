namespace Ulbraflix.entities;

public abstract class Title
{
    public int Id;
    public string Name;
    public string Sinopsis;
    public bool IsWatched;
    public List<Category> Categories;
    public Rating Rating;
}