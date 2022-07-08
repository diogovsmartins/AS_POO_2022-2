using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ulbraflix.domain.entities;

public abstract class Title
{
    [Key] 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Sinopsis { get; set; }
    public bool IsWatched { get; set; }
    public List<Category> Categories { get; set; }
    public Rating Rating { get; set; }
}