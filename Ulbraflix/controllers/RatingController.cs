using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers;


[ApiController]
[Route("rating")]
public class RatingController : ControllerBase
{
    private readonly IRatingService _ratingService;
        
        
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          Rating rating=_ratingService.GetById(id);
          RatingRecordVO ratingRecord = new RatingRecordVO(rating.RatingValue);
          return Ok(ratingRecord);
        }


        [HttpGet("async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Rating rating=await _ratingService.GetByIdAsync(id);
            RatingRecordVO ratingRecord = new RatingRecordVO(rating.RatingValue);
            return Ok(ratingRecord);
        }
        
        
        [HttpGet("async/")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Rating> ratings = new List<Rating>();
            ratings.AddRange(await _ratingService.GetAllAsync());
            List<RatingRecordVO> ratingRecords = new List<RatingRecordVO>();
            ratings.ForEach(rating =>
            {
                RatingRecordVO ratingRecordVO = new RatingRecordVO(rating.RatingValue);
                ratingRecords.Add(ratingRecordVO);
            });
            return Ok(ratingRecords);
        }
        
        [HttpGet]
        public  IActionResult GetAll()
        {
            List<Rating> ratings = new List<Rating>();
            ratings.AddRange(_ratingService.GetAll());
            List<RatingRecordVO> ratingRecordVOs = new List<RatingRecordVO>();
            ratings.ForEach(rating =>
            {
                RatingRecordVO ratingRecord = new RatingRecordVO(rating.RatingValue);
                ratingRecordVOs.Add(ratingRecord);
            });
            return Ok(ratingRecordVOs);
        }

        [HttpPost ("insert")]
        public IActionResult InsertRating([FromBody] RatingRecord ratingRecord)
        {
            try
            {
                if (ratingRecord.Equals(null))
                    return new BadRequestResult();
                Rating rating = new Rating();
                rating.RatingValue = ratingRecord.RatingValue;
            
                if (_ratingService.Insert(rating))
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
        public IActionResult UpdateRating([FromBody] RatingRecord ratingRecord)
        {
            try
            {
                if (ratingRecord.Equals(null))
                    return new BadRequestResult();
                
                Rating rating = new Rating();
                rating.Id = ratingRecord.Id;
                rating.RatingValue = ratingRecord.RatingValue;
            
                if (_ratingService.Update(rating))
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
        public IActionResult DeleteRating(int id)
        {
            try
            {
                if (_ratingService.Delete(id))
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
