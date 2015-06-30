namespace Asn2_GoodSam.Migrations.UserMigrations
{
    using Asn2_GoodSam.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class UserConfiguration : DbMigrationsConfiguration<Asn2_GoodSam.Models.ApplicationDbContext>
    {
        public UserConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\UserMigrations";
        }

        protected override void Seed(Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(
              r => r.Name,
                  new IdentityRole
                  {
                      Name = "Administrator"
                  },
                  new IdentityRole
                  {
                      Name = "Worker"
                  },
                  new IdentityRole
                  {
                      Name = "Report"
                  }
          );
            context.SaveChanges();

            var hasher = new PasswordHasher();
            context.Users.AddOrUpdate(
                u => u.UserName,
                    new ApplicationUser
                    {
                        UserName = "adam@gs.ca",
                        PasswordHash = hasher.HashPassword("P@$$w0rd"),
                        Email = "adam@gs.ca",
                        LockoutEnabled = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    },
                    new ApplicationUser
                    {
                        UserName = "wendy@gs.ca",
                        PasswordHash = hasher.HashPassword("P@$$w0rd"),
                        Email = "wendy@gs.ca",
                        LockoutEnabled = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    },
                    new ApplicationUser
                    {
                        UserName = "rob@gs.ca",
                        PasswordHash = hasher.HashPassword("P@$$w0rd"),
                        Email = "rob@gs.ca",
                        LockoutEnabled = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                );
            context.SaveChanges();


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            userManager.AddToRole(userManager.FindByName("adam@gs.ca").Id, "Administrator");
            userManager.AddToRole(userManager.FindByName("wendy@gs.ca").Id, "Worker");
            userManager.AddToRole(userManager.FindByName("rob@gs.ca").Id, "Report");

            context.SaveChanges();
        }
    }
}
