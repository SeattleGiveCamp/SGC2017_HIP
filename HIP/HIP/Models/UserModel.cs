using System;
namespace HIP.MobileAppService.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsMinor { get; set; }

        public UserModel(string email)
        {
            FirstName = "";
            LastName = "";
            Email = email;
            IsMinor = false;
        }

        public UserModel(string email, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsMinor = false;
        }
    }
}
