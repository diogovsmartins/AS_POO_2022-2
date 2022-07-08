using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          User user=_userService.GetById(id);
          UserRecordVO userRecordVo = new UserRecordVO(user.Email);
          return Ok(userRecordVo);
        }


        [HttpGet("async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            User user=await _userService.GetByIdAsync(id);
            UserRecordVO userRecordVo = new UserRecordVO(user.Email);
            return Ok(userRecordVo);
        }
        
        
        [HttpGet("async")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<User> users = new List<User>();
            users.AddRange(await _userService.GetAllAsync());
            List<UserRecordVO> userRecordVos = new List<UserRecordVO>();
            users.ForEach(user =>
            {
                UserRecordVO userRecordVo = new UserRecordVO(user.Email);
                userRecordVos.Add(userRecordVo);
            });
            return Ok(userRecordVos);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = new List<User>();
            users.AddRange(_userService.GetAll());
            List<UserRecordVO> userRecordVos = new List<UserRecordVO>();
            users.ForEach(user =>
            {
                UserRecordVO userRecordVo = new UserRecordVO(user.Email);
                userRecordVos.Add(userRecordVo);
            });
            return Ok(userRecordVos);
        }

        [HttpPost ("insert")]
        public IActionResult InsertUser([FromBody] UserRecord userRecord)
        {
            if (userRecord.Equals(null) ||
                userRecord.Email.Equals(""))
                return new BadRequestResult();
            
            User user = new User();
            user.Email = userRecord.Email;
            user.Password = userRecord.Password;
            try
            {
                if (_userService.Insert(user))
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
        public IActionResult UpdateUser([FromBody] UserRecord userRecord)
        {
            if (userRecord.Equals(null) ||
                userRecord.Email.Equals(""))
                return new BadRequestResult();
            
            User user = new User();
            user.Id = userRecord.Id;
            user.Email = userRecord.Email;
            user.Password = userRecord.Password;
            try
            {
                if (_userService.Update(user))
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
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (_userService.Delete(id))
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
