using MasterRegUser.Entities;
using MasterRegUser.Insfrastructures;
using MasterRegUser.Models;

namespace MasterRegUser.Services
{
    public class UserService :DBConfig,IUser
    {
        public async Task<(bool Error, GeneralResponses Data)> RegisterAccount(RegisterAccountDTO Entity)
        {
            try
            {
                var CheckEmail = UserAccount.Where(es => es.EmailAddress == Entity.EmailAddress).Any();
                if(CheckEmail==true)

                {
                    var Return = new GeneralResponses()
                    {
                        Error = true,
                        Message = "Another User With Current Email Already Exists, Please Use Another Email Address !!!"
                    };
                    return (Return.Error, Return);
                }
                if(Entity.Passwords.Trim()!=Entity.RePassword.Trim())
                {
                    var Return = new GeneralResponses()
                    {
                        Error = true,
                        Message = "Password Doesn't Match, Retype Your Choice Password Carefully !!!"
                    };
                    return (Return.Error, Return);
                }
                else
                {

                    var Uid = new Guid();

                    var DataUser = new UserAccount()
                {
                    UserNumber=Uid.ToString(),
                    Passwords=Entity.Passwords.Trim(),
                    EmailAddress=Entity.EmailAddress,
                    CreatedDated=DateTime.Now,
                    IsActive=true
                };
                    var DataDetail = new UserAccountDetail()
                    {
                        UserNumber=DataUser.UserNumber,
                        NumberPhone=Entity.NumberPhone,
                        FullName=Entity.FullName,
                        
                    };
                    if(String.IsNullOrEmpty(Entity.txtNationality))
                    {
                        DataDetail.Nationality = Entity.dpNationality;
                    }
                    if(String.IsNullOrEmpty(Entity.dpNationality))
                    {
                        DataDetail.Nationality = Entity.txtNationality;
                    }
                    await UserAccount.AddAsync(DataUser);
                    await UserAccountDetail.AddAsync(DataDetail);

                    await SaveChangesAsync();
                    var Return = new GeneralResponses()
                    {
                        Error = false,
                        Message = "Your Account Have Been Saved, You Can Proceed Login Now "
                    };
                    return (Return.Error, Return);
                }
            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Error = true,
                    Message = ex.Message
                };
                return (Return.Error, Return);
            }
        }

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
