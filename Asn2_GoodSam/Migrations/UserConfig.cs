/*namespace Asn2_GoodSam.Migrations
{
    using Asn2_GoodSam.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Asn2_GoodSam.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Administrator"))
                roleManager.Create(new IdentityRole("Administrator"));

            if (!roleManager.RoleExists("Worker"))
                roleManager.Create(new IdentityRole("Worker"));

            if (!roleManager.RoleExists("Report"))
                roleManager.Create(new IdentityRole("Report"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string[] emails = { "adam@gs.ca", "wendy@gs.ca", "rob@gs.ca" };
            if (userManager.FindByEmail(emails[0]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[0],
                    UserName = emails[0],
                };
                var result = userManager.Create(user, "P@$$w0rd");

                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Administrator");
            }
            if (userManager.FindByEmail(emails[1]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[1],
                    UserName = emails[1],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Worker");
            }
            if (userManager.FindByEmail(emails[2]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[2],
                    UserName = emails[2],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Worker");
            }
            


        }
    }
}

*/