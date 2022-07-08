using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          Movie Movie=_movieService.GetById(id);
          MovieRecord MovieRecord = new MovieRecord(
              Movie.Name, 
              Movie.Sinopsis, 
              Movie.IsWatched,
              Movie.Categories,
              Movie.Rating,
              Movie.Duration,
              Movie.LastMinuteWatched
          );
          return Ok(MovieRecord);
        }


        [HttpGet("/async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Movie Movie=await _movieService.GetByIdAsync(id);
            MovieRecord MovieRecordVo = new MovieRecord(
                Movie.Name, 
                Movie.Sinopsis, 
                Movie.IsWatched,
                Movie.Categories,
                Movie.Rating,
                Movie.Duration,
                Movie.LastMinuteWatched
            );
            return Ok(MovieRecordVo);
        }
        
        
        [HttpGet("/async/")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Movie> Movies = new List<Movie>();
            Movies.AddRange(await _movieService.GetAllAsync());
            List<MovieRecord> MovieRecordVos = new List<MovieRecord>();
            Movies.ForEach(Movie =>
            {
                MovieRecord MovieRecordVo = new MovieRecord(
                    Movie.Name, 
                    Movie.Sinopsis, 
                    Movie.IsWatched,
                    Movie.Categories,
                    Movie.Rating,
                    Movie.Duration,
                    Movie.LastMinuteWatched
                    );
                MovieRecordVos.Add(MovieRecordVo);
            });
            return Ok(MovieRecordVos);
        }
        
        [HttpGet]
        public  IActionResult GetAll()
        {
            List<Movie> Movies = new List<Movie>();
            Movies.AddRange(_movieService.GetAll());
            List<MovieRecord> MovieRecords = new List<MovieRecord>();
            Movies.ForEach(Movie =>
            {
                MovieRecord MovieRecord = new MovieRecord(
                    Movie.Name, 
                    Movie.Sinopsis, 
                    Movie.IsWatched,
                    Movie.Categories,
                    Movie.Rating,
                    Movie.Duration,
                    Movie.LastMinuteWatched
                );
                MovieRecords.Add(MovieRecord);
            });
            return Ok(MovieRecords);
        }

        [HttpPost ("/insert")]
        public IActionResult InsertMovie([FromBody] MovieRecord MovieRecord)
        {
            if (MovieRecord.Equals(null))
            return new BadRequestResult();
            
            Movie Movie = new Movie();
            Movie.Name = MovieRecord.Name;
            Movie.Sinopsis = MovieRecord.Sinopsis;
            Movie.IsWatched = MovieRecord.IsWatched;
            Movie.Categories = MovieRecord.Categories;
            Movie.Rating = MovieRecord.Rating;
            Movie.Duration = MovieRecord.Duration;
            Movie.LastMinuteWatched = MovieRecord.LastMinuteWatched;
            return Ok();
        }   
        
        [HttpPut("/update/{id}")]
        public IActionResult UpdateMovie([FromBody] MovieRecord MovieRecord, int id)
        {
            if (MovieRecord.Equals(null))
                return new BadRequestResult();
            
            Movie Movie = new Movie();
            Movie.Name = MovieRecord.Name;
            Movie.Sinopsis = MovieRecord.Sinopsis;
            Movie.IsWatched = MovieRecord.IsWatched;
            Movie.Categories = MovieRecord.Categories;
            Movie.Rating = MovieRecord.Rating;
            Movie.Duration = MovieRecord.Duration;
            Movie.LastMinuteWatched = MovieRecord.LastMinuteWatched;
            _movieService.Update(Movie);
            return Ok();
        }
        
        [HttpDelete("/delete/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            
            if (_movieService.Delete(id))
            {
                return Ok();   
            }
            return BadRequest();
        }
    }
