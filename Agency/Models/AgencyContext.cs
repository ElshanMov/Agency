using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Models
{
    public class AgencyContext:IdentityDbContext
    {
        public AgencyContext(DbContextOptions<AgencyContext> opt):base(opt)
        {

        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        public new DbSet<AppUser> Users { get; set; }
    }
}
