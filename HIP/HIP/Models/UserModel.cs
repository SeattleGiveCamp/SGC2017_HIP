using HIP.Helpers;
using System;
namespace HIP.MobileAppService.Models
{
	public class UserModel
	{
        public static UserModel CurrentUser => 
            new UserModel(Settings.Email, Settings.FirstName, Settings.LastName);

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
        public bool IsMinor { get; set; }
		public string ParentEmail { get; set; }

		public UserModel(string parentEemail)
		{
			FirstName = "";
			LastName = "";
			Email = "";
            IsMinor = false;
			ParentEmail = parentEemail;
		}

		public UserModel(string email, string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
            IsMinor = false;
			ParentEmail = "";
		}
	}
}
