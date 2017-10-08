using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HIP.MobileAppService.Models
{
    public class ProgramType
    {
        [Key]
        public string Name { get; set; }

        public ProgramType(string name)
        {
            Name = name;
        }
    }
}
