using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers;

[ApiController]
[Route("serie")]
public class SerieController : ControllerBase
{
    private readonly ISerieService _serieService;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Serie serie = _serieService.GetById(id);
        SerieRecordVO serieRecordVO = new SerieRecordVO(
            serie.Name,
            serie.Sinopsis,
            serie.IsWatched,
            serie.Categories,
            serie.Rating,
            serie.Seasons);
        return Ok(serieRecordVO);
    }

    [HttpGet("async/{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Serie serie = _serieService.GetById(id);
        SerieRecordVO serieRecordVO = new SerieRecordVO(
            serie.Name,
            serie.Sinopsis,
            serie.IsWatched,
            serie.Categories,
            serie.Rating,
            serie.Seasons);
        return Ok(serieRecordVO);
    }
    [HttpGet("async")]
    public async Task<IActionResult> GetAllAsync()
    {
        List<Serie> Series = new List<Serie>();
        Series.AddRange(await _serieService.GetAllAsync());
        List<SerieRecordVO> SerieRecords = new List<SerieRecordVO>();
        Series.ForEach(serie =>
        {
            SerieRecordVO SerieRecordVo = new SerieRecordVO(
                serie.Name,
                serie.Sinopsis,
                serie.IsWatched,
                serie.Categories,
                serie.Rating,
                serie.Seasons);
            SerieRecords.Add(SerieRecordVo);
        });
        return Ok(SerieRecords);
    }
    [HttpGet]
    public  IActionResult GetAll()
    {
        List<Serie> Series = new List<Serie>();
        Series.AddRange(_serieService.GetAll());
        List<SerieRecordVO> SerieRecords = new List<SerieRecordVO>();
        Series.ForEach(serie =>
        {
            SerieRecordVO SerieRecord = new SerieRecordVO(
                serie.Name,
                serie.Sinopsis,
                serie.IsWatched,
                serie.Categories,
                serie.Rating,
                serie.Seasons);
            SerieRecords.Add(SerieRecord);
        });
        return Ok(SerieRecords);
    }
    [HttpPost ("insert")]
    public IActionResult InsertSerie([FromBody] SerieRecord SerieRecord)
    {
        try
        {
            if (SerieRecord.Equals(null))
                return new BadRequestResult();
                
            Serie Serie = new Serie();
            Serie.Name = SerieRecord.Name;
            Serie.Sinopsis = SerieRecord.Sinopsis;
            Serie.Seasons = SerieRecord.Seasons;
            Serie.IsWatched = SerieRecord.IsWatched;
            Serie.Categories = SerieRecord.Categories;
            Serie.Rating = SerieRecord.Rating;
            
            if (_serieService.Insert(Serie))
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
    [HttpPut("update")]
    public IActionResult UpdateSerie([FromBody] SerieRecord SerieRecord)
    {
        try
        {
            if (SerieRecord.Equals(null))
                return new BadRequestResult();
                
            Serie Serie = new Serie();
            Serie.Id = SerieRecord.Id;
            Serie.Name = SerieRecord.Name;
            Serie.Sinopsis = SerieRecord.Sinopsis;
            Serie.Seasons = SerieRecord.Seasons;
            Serie.IsWatched = SerieRecord.IsWatched;
            Serie.Categories = SerieRecord.Categories;
            Serie.Rating = SerieRecord.Rating;
            
            if (_serieService.Update(Serie))
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
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteSerie(int id)
    {
        try
        {
            if (_serieService.Delete(id))
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