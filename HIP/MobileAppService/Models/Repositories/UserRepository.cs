using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace HIP.MobileAppService.Models
{
	public class UserRepository : IUserRepository
	{

		public UserRepository()
		{ }

		public UserModel Get(string email)
		{
            using (var db = new HIPContext())
            {
                var users = db.Users
                    .Where(b => b.Email == email)
                    .ToList();

                return users.ElementAt(0);
            }
        }

		public List<UserModel> GetAll()
		{
			return new HIPContext().Users.ToList();
		}

		public void Add(UserModel user)
		{
			using (var db = new HIPContext())
			{
                var existingUsers = db.Users.Where(u => u.Email == user.Email).ToList();
                if (existingUsers != null && existingUsers.Count() > 0){
                    Update(existingUsers.First());
                }
                else{
					db.Users.Add(user);
					db.SaveChanges();
                }
			}
		}

		public bool Remove(string id)
		{
            throw new Exception("removing is not currently supported");
		}

		public void Update(UserModel user)
		{
			if (user.Email == null || user.ParentEmail == null)
			{
				throw new Exception("in order to update a user, and email must be present");
			}
			if (user.FirstName == null || user.LastName == null)
			{
				throw new Exception("in order to update an existing user, both first and last names must be provided");
			}
			using (var db = new HIPContext())
			{
				var users = db.Users.Attach(user);
				db.SaveChanges();
			}
		}
	}
}
