using System;
using System.Collections.Generic;
using System.Text;

namespace HIP.MobileAppService.Models
{
    public class ProgramType
    {
        public string Name { get; set; }

        public ProgramType(string name)
        {
            Name = name;
        }
    }
}
