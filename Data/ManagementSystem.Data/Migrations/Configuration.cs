namespace ManagementSystem.Data.Migrations
{
    using ManagementSystem.Common;
    using ManagementSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ManagementSystem.Data.ManagementSystemDbContext>
    {
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ManagementSystem.Data.ManagementSystemDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));

            if (context.Users.FirstOrDefault(u => u.Email == "manager@com.com") == null)
            {
                if (context.Roles.FirstOrDefault(r => r.Name == GlobalConstants.ManagerRole) == null)
                {
                    var adminRole = new IdentityRole(GlobalConstants.ManagerRole);
                    context.Roles.Add(adminRole);
                    context.SaveChanges();
                }

                var user = new User();
                user.Email = "manager@com.com";
                user.UserName = user.Email;
                this.userManager.Create(user, "manager");
                this.userManager.AddToRole(user.Id, GlobalConstants.ManagerRole);
                context.SaveChanges();
            }

            var usersInDb = context.Users.Count();
            var minUsers = 5;
            if (usersInDb < minUsers)
            {
                this.userManager = new UserManager<User>(new UserStore<User>(context));
                while (usersInDb < minUsers)
                {
                    var nextUserNumber = usersInDb;
                    var user = new User();
                    user.Email = "user" + nextUserNumber.ToString() + "@com.com";
                    user.UserName = user.Email;
                    this.userManager.Create(user, "111111");
                    context.SaveChanges();
                    usersInDb = context.Users.Count();
                }
            }

        }
    }
}
