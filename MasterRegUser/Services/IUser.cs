using MasterRegUser.Models;

namespace MasterRegUser.Services
{
    public interface IUser
    {
        public Task<(bool Error, GeneralResponses Data)> GetLogin(RequestlOGINDTO Entity);
        public Task<(bool Error, GeneralResponses Data)> RegisterAccount(RegisterAccountDTO Entity);
        public Task<(bool Error, GeneralResponses Data)> GetGridUser(string Email);

    }
}
