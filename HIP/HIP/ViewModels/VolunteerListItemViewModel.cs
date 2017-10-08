using System;
using HIP.Models;
using HIP.MobileAppService.Models;

namespace HIP
{
	public class VolunteerListItemViewModel
	{
		public VolunteerListItemViewModel(UserModel model)
		{
			Model = model;
		}

        public UserModel Model { get;  }

        public string DisplayName
        {
            get
            {
                if (Model.IsMinor)
                {
                    return "(minor - name not recorded)";

                }

                string displayName = "";
                if (!string.IsNullOrEmpty(Model.FirstName))
                {
                    displayName += Model.FirstName;
                }

                if (!string.IsNullOrEmpty(Model.LastName))
                {
                    if (!string.IsNullOrEmpty(displayName))
                    {
                        displayName += " ";
                    }

                    displayName += Model.LastName;
                }

                if (string.IsNullOrEmpty(displayName) && !string.IsNullOrEmpty(Model.Email))
                {
                    displayName = Model.Email;
                }

                if (string.IsNullOrEmpty(displayName))
                {
                    displayName = "(unknown)";
                }

                return displayName;
            }
        }

	}
}
