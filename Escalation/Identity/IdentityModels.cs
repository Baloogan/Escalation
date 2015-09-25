using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System;

namespace Escalation.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        private IdentityContext(string connString)
            : base(connString, throwIfV1Schema: false)
        {

            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<IdentityContext, ApplicationDbConfiguration>());

        }

        public static IdentityContext Create()
        {
            if (Environment.MachineName.ToUpper() == "STONEBURNER")
                return new IdentityContext("IdentityContext_Stoneburner");
            else
                return new IdentityContext("IdentityContext_Server");
        }

    }

    internal sealed class ApplicationDbConfiguration : DbMigrationsConfiguration<IdentityContext>
    {
        public ApplicationDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(IdentityContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!RoleManager.RoleExists("Admin"))
            {
                RoleManager.Create(new IdentityRole("Admin"));
            }
            if (UserManager.FindByName("Baloogan") == null)
            {
                UserManager.Create(new ApplicationUser()
                {
                    UserName = "Baloogan",
                    Email = "baloogan@gmail.com"
                }, System.IO.File.ReadAllText(@"C:\AutoBalooganConfig\baloogan_password.txt").Trim());
            }
            if (!UserManager.IsInRole(UserManager.FindByName("Baloogan").Id, "Admin"))
            {
                UserManager.AddToRole(UserManager.FindByName("Baloogan").Id, "Admin");
            }
        }
    }
}