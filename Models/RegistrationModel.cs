namespace Healthify1.Models
{
    public class RegistrationModel
    {
        public int? UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsAdmin { get; set; }
        /*public string ConfirmedPassword { get; set; }*/
    }
}
