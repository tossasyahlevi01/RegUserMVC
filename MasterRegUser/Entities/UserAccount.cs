namespace MasterRegUser.Entities
{
    public class UserAccount
    {
        public string UserNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Passwords { get; set; }
        public DateTime CreatedDated { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifyDated { get; set; }
    }
}
