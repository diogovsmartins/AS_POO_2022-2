﻿using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers;


[ApiController]
[Route("[controller]")]
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
          RatingRecord ratingRecord = new RatingRecord(rating.RatingValue);
          return Ok(ratingRecord);
        }


        [HttpGet("/async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Rating rating=await _ratingService.GetByIdAsync(id);
            RatingRecord ratingRecord = new RatingRecord(rating.RatingValue);
            return Ok(ratingRecord);
        }
        
        
        [HttpGet("/async/")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Rating> ratings = new List<Rating>();
            ratings.AddRange(await _ratingService.GetAllAsync());
            List<RatingRecord> ratingRecords = new List<RatingRecord>();
            ratings.ForEach(rating =>
            {
                RatingRecord ratingRecordVo = new RatingRecord(rating.RatingValue);
                ratingRecords.Add(ratingRecordVo);
            });
            return Ok(ratingRecords);
        }
        
        [HttpGet]
        public  IActionResult GetAll()
        {
            List<Rating> ratings = new List<Rating>();
            ratings.AddRange(_ratingService.GetAll());
            List<RatingRecord> ratingRecordVos = new List<RatingRecord>();
            ratings.ForEach(rating =>
            {
                RatingRecord ratingRecord = new RatingRecord(rating.RatingValue);
                ratingRecordVos.Add(ratingRecord);
            });
            return Ok(ratingRecordVos);
        }

        [HttpPost ("/insert")]
        public IActionResult InsertRating([FromBody] RatingRecord ratingRecord)
        {
            if (ratingRecord.Equals(null))
                return new BadRequestResult();
            Rating rating = new Rating();
            rating.RatingValue = ratingRecord.RatingValue;
            _ratingService.Insert(rating);
            return Ok();
        }
        
        [HttpPut("/update/{id}")]
        public IActionResult UpdateRating([FromBody] RatingRecord ratingRecord, int id)
        {
            if (ratingRecord.Equals(null))
                return new BadRequestResult();
            
            Rating rating = new Rating();
            rating.RatingValue = ratingRecord.RatingValue;
            _ratingService.Update(rating, id);
            return Ok();
        }
        
        [HttpDelete("/delete/{id}")]
        public IActionResult DeleteRating(int id)
        {
            if(_ratingService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}