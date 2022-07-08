using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers;

[ApiController]
[Route("userprofile")]
public class UserProfileController : ControllerBase
{
     private readonly IUserProfileService _userProfileService;
        
        
    public UserProfileController(IUserProfileService userProfileService)
    {
        _userProfileService = userProfileService;
    }
    
    [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          UserProfile userProfile=_userProfileService.GetById(id);
          UserProfileRecordVO userProfileRecord =
              new UserProfileRecordVO(userProfile.Name, userProfile.WatchHistory);
          return Ok(userProfileRecord);
        }


        [HttpGet("async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            UserProfile userProfile=await _userProfileService.GetByIdAsync(id);
            UserProfileRecordVO userProfileRecord = new UserProfileRecordVO(userProfile.Name, userProfile.WatchHistory);
            return Ok(userProfileRecord);
        }
        
        
        [HttpGet("async")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<UserProfile> userProfiles = new List<UserProfile>();
            userProfiles.AddRange(await _userProfileService.GetAllAsync());
            List<UserProfileRecordVO> userProfileRecords = new List<UserProfileRecordVO>();
            userProfiles.ForEach(userProfile =>
            {
                UserProfileRecordVO userProfileRecord = new UserProfileRecordVO(userProfile.Name, userProfile.WatchHistory);
                userProfileRecords.Add(userProfileRecord);
            });
            return Ok(userProfileRecords);
        }
        
        [HttpGet]
        public  IActionResult GetAll()
        {
            List<UserProfile> userProfiles = new List<UserProfile>();
            userProfiles.AddRange( _userProfileService.GetAll());
            List<UserProfileRecordVO> userProfileRecords = new List<UserProfileRecordVO>();
            userProfiles.ForEach(userProfile =>
            {
                UserProfileRecordVO userProfileRecord = new UserProfileRecordVO(userProfile.Name, userProfile.WatchHistory);
                userProfileRecords.Add(userProfileRecord);
            });
            return Ok(userProfileRecords);
        }

        [HttpPost ("insert")]
        public IActionResult InsertUserProfile([FromBody] UserProfileRecord userProfileRecord)
        {
            if (userProfileRecord.Equals(null))
                return new BadRequestResult();
            UserProfile userProfile = new UserProfile();
            userProfile.Name = userProfileRecord.Name;
            userProfile.WatchHistory = userProfileRecord.WatchHistory;
            try
            {
                if (_userProfileService.Insert(userProfile))
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
        public IActionResult UpdateUserProfile([FromBody] UserProfileRecord userProfileRecord)
        {
            if (userProfileRecord.Equals(null))
                return new BadRequestResult();
            
            UserProfile userProfile = new UserProfile();
            userProfile.Id = userProfileRecord.Id;
            userProfile.Name = userProfileRecord.Name;
            userProfile.WatchHistory = userProfileRecord.WatchHistory;
            try
            {
                if (_userProfileService.Update(userProfile))
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
        public IActionResult DeleteUserProfile(int id)
        {
            try
            {
                if (_userProfileService.Delete(id))
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