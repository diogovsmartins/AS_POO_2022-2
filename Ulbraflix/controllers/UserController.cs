using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.controllers
{


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
    {
        //TODO:Adicionar a service correspondente :D
        public UserController(UserService userService)
        {
            //TODO:Inicializar o service correspondente xD
        }
        [HttpGet]
        public Task<User> GetUsers()
        {
            
        }

    
        [HttpGet("{id:int}")]
        public ActionResult GetUserById(int id)
        {
            
        }

    
        [HttpPost]
        public IActionResult InsertUser([FromBody] User user)
        {
            
        }

        [HttpPut]
        public ActionResult UpdateUser([FromBody] User user)
        {
            
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteUser(int id)
        {
            
        }
    }
}