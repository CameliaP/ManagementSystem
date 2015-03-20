using ManagementSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;

namespace ManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
