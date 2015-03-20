using System.Data.Entity;
using ManagementSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using ManagementSystem.Data.Migrations;

namespace ManagementSystem.Data
{
    public class ManagementSystemDbContext : IdentityDbContext<User>
    {
        public ManagementSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ManagementSystemDbContext, Configuration>());
        }

        public static ManagementSystemDbContext Create()
        {
            return new ManagementSystemDbContext();
        }
    }
}
