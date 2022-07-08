using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers;

public class SeasonController : ControllerBase
{
    private readonly ISeasonService _seasonService;
        
        
    public SeasonController(ISeasonService seasonService)
    {
        _seasonService = seasonService;
    }
    
    [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          Season season=_seasonService.GetById(id);
          SeasonRecord seasonRecord = new SeasonRecord(season.Episode);
          return Ok(seasonRecord);
        }


        [HttpGet("/async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Season season=await _seasonService.GetByIdAsync(id);
            SeasonRecord seasonRecord = new SeasonRecord(season.Episode);
            return Ok(seasonRecord);
        }
        
        
        [HttpGet("/async/")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Season> seasons = new List<Season>();
            seasons.AddRange(await _seasonService.GetAllAsync());
            List<SeasonRecord> seasonRecords = new List<SeasonRecord>();
            seasons.ForEach(season =>
            {
                SeasonRecord seasonRecord = new SeasonRecord(season.Episode);
                seasonRecords.Add(seasonRecord);
            });
            return Ok(seasonRecords);
        }
        
        [HttpGet]
        public  IActionResult GetAll()
        {
            List<Season> seasons = new List<Season>();
            seasons.AddRange( _seasonService.GetAll());
            List<SeasonRecord> seasonRecords = new List<SeasonRecord>();
            seasons.ForEach(season =>
            {
                SeasonRecord seasonRecord = new SeasonRecord(season.Episode);
                seasonRecords.Add(seasonRecord);
            });
            return Ok(seasonRecords);
        }

        [HttpPost ("/insert")]
        public IActionResult InsertSeason([FromBody] SeasonRecord seasonRecord)
        {
            if (seasonRecord.Equals(null))
                return new BadRequestResult();
            Season season = new Season();
            season.Episode = seasonRecord.Episodes;
            try
            {
                if (_seasonService.Insert(season))
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
        public IActionResult UpdateSeason([FromBody] SeasonRecord seasonRecord)
        {
            if (seasonRecord.Equals(null))
                return new BadRequestResult();
            
            Season season = new Season();
            season.Episode = seasonRecord.Episodes;
            try
            {
                if (_seasonService.Update(season))
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
        public IActionResult DeleteSeason(int id)
        {
            try
            {
                if (_seasonService.Delete(id))
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