using MasterRegUser.Models.DTO;

namespace MasterRegUser.Models
{
    public class GeneralResponses
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public GeneralContent Data { get; set; }
    }
    public class GeneralContent
    {
        public List<UserDTO> ListUser { get; set; }
    }
}
