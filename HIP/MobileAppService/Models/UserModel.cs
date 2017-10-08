using System;
using System.ComponentModel.DataAnnotations;

namespace HIP.MobileAppService.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Email { get; set; }

		public UserModel()
        {}

        public UserModel(string email)
        {
            FirstName = "";
            LastName = "";
            Email = email;
        }

        public UserModel(string email, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
