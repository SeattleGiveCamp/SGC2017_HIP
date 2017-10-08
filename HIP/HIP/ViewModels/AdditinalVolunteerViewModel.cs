using System;
using HIP.MobileAppService.Models;

namespace HIP.ViewModels
{
    public class AdditionalVolunteerViewModel
    {
        

        public AdditionalVolunteerViewModel()
        {
            
        }

        public bool IsChild { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailName { get; set; }
    }
}
