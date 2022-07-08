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
          Movie Movie = _movieService.GetById(id);
          MovieRecordVO MovieRecord = new MovieRecordVO(
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
            Movie Movie = await _movieService.GetByIdAsync(id);
            MovieRecordVO MovieRecordVo = new MovieRecordVO(
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
            List<MovieRecordVO> MovieRecordVos = new List<MovieRecordVO>();
            Movies.ForEach(Movie =>
            {
                MovieRecordVO MovieRecordVo = new MovieRecordVO(
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
            List<MovieRecordVO> MovieRecords = new List<MovieRecordVO>();
            Movies.ForEach(Movie =>
            {
                MovieRecordVO MovieRecord = new MovieRecordVO(
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
            try
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
            
                if (_movieService.Insert(Movie))
                {
                    return Ok("Successfully inserted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return BadRequest();
        }   
        
        [HttpPut("/update")]
        public IActionResult UpdateMovie([FromBody] MovieRecord MovieRecord)
        {
            try
            {
                if (MovieRecord.Equals(null))
                    return new BadRequestResult();
                
                Movie Movie = new Movie();
                Movie.Id = MovieRecord.Id;
                Movie.Name = MovieRecord.Name;
                Movie.Sinopsis = MovieRecord.Sinopsis;
                Movie.IsWatched = MovieRecord.IsWatched;
                Movie.Categories = MovieRecord.Categories;
                Movie.Rating = MovieRecord.Rating;
                Movie.Duration = MovieRecord.Duration;
                Movie.LastMinuteWatched = MovieRecord.LastMinuteWatched;
            
                if (_movieService.Update(Movie))
                {
                    return Ok("Successfully updated");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return BadRequest();
        }
        
        [HttpDelete("/delete/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                if (_movieService.Delete(id))
                {
                    return Ok("Successfully deleted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return BadRequest();
        }
    }
