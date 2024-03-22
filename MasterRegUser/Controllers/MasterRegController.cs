using MasterRegUser.Models;
using MasterRegUser.Services;
using Microsoft.AspNetCore.Mvc;

namespace MasterRegUser.Controllers
{
    public partial class MasterRegController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private IUser _User { get; set; }
        public MasterRegController(IUser User)
        {
            _User = User;
        }


        [ActionName("GetSession")]
        public async Task<IActionResult> GetSession()
        {
            try
            {
                if (String.IsNullOrEmpty(HttpContext.Session.GetString("Email").ToString()))
                {
                    var Return = new GeneralResponses()
                    {
                        Error = true,
                        Message = "Session Null"
                    };
                    return BadRequest(Return);
                }
                else
                {
                    var SessionEmail = HttpContext.Session.GetString("Email").ToString();
                    var Return = new GeneralResponses()
                    {
                        Error = false,
                        Message = SessionEmail
                    };
                    return Ok(Return);
                }

             
            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Error = true,
                    Message = ex.Message
                };
                return BadRequest(Return);

            }
        }

        [ActionName("GetGridUser")]
        public async Task<IActionResult> GetGridUser()
        {
            try
            {
                if (String.IsNullOrEmpty(HttpContext.Session.GetString("Email").ToString()))
                {
                    var Return = new GeneralResponses()
                    {
                        Error = true,
                        Message = "Session Null"
                    };
                    return BadRequest(Return);
                }
                else
                {
                    var SessionEmail = HttpContext.Session.GetString("Email").ToString();
                    var Data = await _User.GetGridUser(SessionEmail);
                    if(Data.Error==true)
                    {
                        var Return = new GeneralResponses()
                        {
                            Error = true,
                            Message = Data.Data.Message
                        };
                        return BadRequest(Return);
                    }
                    else
                    {
                        var Return = new GeneralResponses()
                        {
                            Error = false,
                            Message = SessionEmail,
                            Data=Data.Data.Data
                        };
                        return Ok(Return);
                    }
                  
                }


            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Error = true,
                    Message = ex.Message
                };
                return BadRequest(Return);

            }
        }

        [ActionName("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                var SessionEmail = HttpContext.Session.GetString("Email").ToString();
                HttpContext.Session.Clear();
                var Return = new GeneralResponses()
                {
                    Error = false,
                    Message = "LogOut Successfully"
                };
                return Ok(Return);
            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Error = true,
                    Message = ex.Message
                };
                return BadRequest(Return);

            }
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
                    var Data = await _User.GetLogin(Entity);
                    HttpContext.Session.SetString("Email", Entity.Email);


                    if (Data.Error==true)
                    {
                        var Return = new GeneralResponses()
                        {
                            Error = Data.Error,
                            Message = Data.Data.Message
                        };
                        return Ok(Return);

                    }
                    else
                    {
                        var Return = new GeneralResponses()
                        {
                            Error = Data.Error,
                            Message = Data.Data.Message
                        };
                        return Ok(Return);
                    }
                
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

        [ActionName("RegisterAccounts")]
        public async Task<IActionResult> RegisterAccounts([FromBody] RegisterAccountDTO Entity)
        {
            try
            {
                

                if (String.IsNullOrEmpty(Entity.NumberPhone) || String.IsNullOrEmpty(Entity.EmailAddress) ||
                     String.IsNullOrEmpty(Entity.Passwords))
                {
                    var Return = new GeneralResponses()
                    {
                        Error = true,
                        Message = "You Must Enter Registration Field Input"
                    };
                    return BadRequest(Return);
                }
                else
                {
                    var Data = await _User.RegisterAccount(Entity);
                    if(Data.Error==true)
                    {
                        var Return = new GeneralResponses()
                        {
                            Error = Data.Error,
                            Message = Data.Data.Message
                        };
                        return BadRequest(Return);
                    }
                    else
                    {
                        var Return = new GeneralResponses()
                        {
                            Error = false,
                            Message = Data.Data.Message
                        };
                        return Ok(Return);
                    }
                  
                }
            }
            catch (Exception ex)
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
