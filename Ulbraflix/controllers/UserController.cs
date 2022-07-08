using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers
{


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
    {
        //TODO:Adicionar a service correspondente :D
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;
        private readonly IWatchHistoryService _watchHistoryService;
        
        public UserController(
            IUserService userService,
            IUserProfileService userProfileRepository,
            IWatchHistoryService watchHistoryService)
        {
            _userService = userService;
            _userProfileService = userProfileRepository;
            _watchHistoryService = watchHistoryService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          User user=_userService.GetById(id);
          UserRecordVO userRecordVo = new UserRecordVO(user.Email);
          return Ok(userRecordVo);
        }


        [HttpGet("/async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            User user=await _userService.GetByIdAsync(id);
            UserRecordVO userRecordVo = new UserRecordVO(user.Email);
            return Ok(userRecordVo);
        }
        
        
        [HttpGet("/async/")]
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
        public  IActionResult GetAll()
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

        [HttpPost ("/insert")]
        public IActionResult InsertUser([FromBody] UserRecord userRecord)
        {
            if (userRecord.Equals(null) ||
                userRecord.Email.Equals(""))
                return new BadRequestResult();
            
            User user = new User();
            user.Email = userRecord.Email;
            user.Password = userRecord.Password;
            _userService.Insert(user);
            return Ok();
        }
        
        [HttpPut("/update/{id}")]
        public IActionResult UpdateUser([FromBody] UserRecord userRecord, int id)
        {
            if (userRecord.Equals(null) ||
                userRecord.Email.Equals(""))
                return new BadRequestResult();
            
            User user = new User();
            user.Email = userRecord.Email;
            user.Password = userRecord.Password;
            _userService.Update(user, id);
            return Ok();
        }
        
        [HttpDelete("/delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
        
        




    }
}