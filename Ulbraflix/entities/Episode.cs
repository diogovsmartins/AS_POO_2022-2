﻿using System.ComponentModel.DataAnnotations;

namespace Ulbraflix.entities;

public class Episode
{
    public int Id { get; set; }
    public string Sinopsis { get; set; }
    public int Duration { get; set; }
    public int LastMinuteWatched { get; set; }
}