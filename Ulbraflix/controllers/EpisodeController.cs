using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers;

[ApiController]
[Route("episode")]
public class EpisodeController : ControllerBase
{
    private readonly IEpisodeService _episodeService;

    public EpisodeController(IEpisodeService episodeService)
    {
        this._episodeService = episodeService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Episode episode = _episodeService.GetById(id);
        EpisodeRecordVO episodeRecord = new EpisodeRecordVO(episode.Sinopsis, episode.Duration, episode.LastMinuteWatched);
        return Ok(episodeRecord);
    }

    [HttpGet("async/{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Episode episode = await _episodeService.GetByIdAsync(id);
        EpisodeRecordVO episodeRecord = new EpisodeRecordVO(episode.Sinopsis, episode.Duration, episode.LastMinuteWatched);
        return Ok(episodeRecord);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Episode> episodes = _episodeService.GetAll();
        List<EpisodeRecordVO> episodeRecords = new List<EpisodeRecordVO>();
        episodes.ForEach(episode =>
        {
            EpisodeRecordVO episodeRecord = new EpisodeRecordVO(episode.Sinopsis, episode.Duration, episode.LastMinuteWatched);
            episodeRecords.Add(episodeRecord);
        });
        return Ok(episodeRecords);
    }
    
    [HttpGet("async")]
    public async Task<IActionResult> GetAllAsync()
    {
        List<Episode> episodes = new List<Episode>();
        episodes.AddRange(await _episodeService.GetAllAsync());
        List<EpisodeRecordVO> episodeRecords = new List<EpisodeRecordVO>();
        episodes.ForEach(episode =>
        {
            EpisodeRecordVO episodeRecord = new EpisodeRecordVO(episode.Sinopsis, episode.Duration, episode.LastMinuteWatched);
            episodeRecords.Add(episodeRecord);
        });
        return Ok(episodeRecords);
    }

    [HttpPost("insert")]
    public IActionResult InsertEpisode([FromBody] EpisodeRecord episodeRecord)
    {
        try
        {
            if (episodeRecord.Equals(null) ||
                episodeRecord.Duration.Equals(null))
            {
                return new BadRequestResult();
            }

            Episode episode = new Episode();
            episode.Duration = episodeRecord.Duration;
            episode.Sinopsis = episodeRecord.Sinopsis;
            episode.LastMinuteWatched = episodeRecord.LastMinuteWatched;
            if (_episodeService.Insert(episode))
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
    
    [HttpPost("update")]
    public IActionResult UpdateEpisode([FromBody] EpisodeRecord episodeRecord)
    {
        try
        {
            if (episodeRecord.Equals(null) ||
                episodeRecord.Duration.Equals(null) ||
                episodeRecord.Id.Equals(null))
            {
                return new BadRequestResult();
            }

            Episode episode = new Episode();
            episode.Id = episodeRecord.Id;
            episode.Duration = episodeRecord.Duration;
            episode.Sinopsis = episodeRecord.Sinopsis;
            episode.LastMinuteWatched = episodeRecord.LastMinuteWatched;
            if (_episodeService.Insert(episode))
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
    
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            if (_episodeService.Delete(id))
            {
                return Ok("Successfully deleted.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
        
        return BadRequest();
    }
}