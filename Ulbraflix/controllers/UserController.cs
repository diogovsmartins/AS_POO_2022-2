namespace Ulbraflix.controllers
{


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
    {
        //TODO:Adicionar a service correspondente :D
        public UserController(UserService UserService)
        {
            //TODO:Inicializar o service correspondente xD
        }
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            
        }

    
        [HttpGet]
        public ActionResult GetUserById()
        {
            
        }

    
        [HttpPost]
        public IActionResult InsertUser()
        {
            
        }

        [HttpPut]
        public ActionResult UpdateUser()
        {
            
        }

        [HttpDelete]
        public ActionResult DeleteUser()
        {
            
        }
    }
}