using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HIP.MobileAppService.Models
{
    public class HIPContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<EventModel> Events { get; set; }
        public DbSet<EventOccurrence> EventOccurences { get; set; }
        public DbSet<RecurringEventOccurrence> RecurringEventOccurrences { get; set; }
        public DbSet<EventBlackout> EventBlackouts { get; set; }
        public DbSet<EventCheckInModel> EventCheckIns { get; set; }
        //public DbSet<ProgramType> ProgramTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = tcp:hungerintervention.database.windows.net, 1433; Initial Catalog = HIP; Persist Security Info = False; User ID = HIP; Password = 9f#MfX-aU^+?CPaq; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
    }
}
