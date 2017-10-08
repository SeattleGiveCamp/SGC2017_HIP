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
		public string ParentEmail { get; set; }

        public UserModel()
        {}

		public UserModel(string parentEemail)
		{
			FirstName = "";
			LastName = "";
            Email = "";
            ParentEmail = parentEemail;
		}

		public UserModel(string email, string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			ParentEmail = "";
		}

	}
}
