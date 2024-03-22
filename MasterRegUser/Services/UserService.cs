using MasterRegUser.Insfrastructures;
using MasterRegUser.Models;

namespace MasterRegUser.Services
{
    public class UserService :DBConfig,IUser
    {
        public async Task<(bool Error,GeneralResponses Data)>GetLogin(RequestlOGINDTO Entity)
        {
            try
            {
                var Data = UserAccount.Where(es => es.IsActive == true && es.EmailAddress == Entity.Email && es.Passwords == Entity.Password).Any();
                if(Data==true)
                {
                    var Return = new GeneralResponses()
                    {
                        Error = false,
                        Message = "OK"
                    };
                    return (Return.Error, Return);
                }
                else
                {
                    var Return = new GeneralResponses()
                    {
                        Error = true,
                        Message = "User Not Found"
                    };
                    return (Return.Error, Return);

                }
            }
            catch(Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Error=true,
                    Message=ex.Message
                };
                return (Return.Error, Return);
            }
        }


    }
}
