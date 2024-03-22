using MasterRegUser.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterRegUser.Controllers
{
    public partial class MasterRegController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Login")]
        public async Task<IActionResult> Login([FromBody] RequestlOGINDTO Entity)
        {
            try
            {
                if(String.IsNullOrEmpty(Entity.Email) || String.IsNullOrEmpty(Entity.Password))
                {
                    var Return = new GeneralResponses()
                    {
                        Error = true,
                        Message = "You Must Enter Username and Password To Login Process"
                    };
                    return BadRequest(Return);
                }
                else
                {
                    var Return = new GeneralResponses()
                    {
                        Error = false,
                        Message = "OK"
                    };
                    return Ok(Return);
                }
            }
            catch(Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Error = true,
                    Message = ex.Message
                };
                return BadRequest(Return);
            }
        }




    }

    
}
