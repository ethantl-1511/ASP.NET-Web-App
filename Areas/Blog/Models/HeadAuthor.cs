using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class HeadAuthor : ApplicationUser
    {
        public int ViewsPerMonth { get; set; }
        public int AuthorsHired { get; set; }
        public int AuthorsLetGo { get; set; }

        // Seed Database with HeadAuthor for testing purposes
        public static void Seed(ApplicationDbContext context)
        {
            // Entity Framework's RoleManager is used to manage roles, RoleStore will store it. Set to variable roleManager.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // Enetity Framework's UserManage does the same as RoleManager, but for Users. Set to variable roleUserManager
            var roleUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // If the role does not exist...
            if (!roleManager.RoleExists("HeadAuthor"))
            {
                // Create HeadAuthor role
                var modRole = new IdentityRole();
                modRole.Name = "HeadAuthor";
                roleManager.Create(modRole);

                // Create an instance of HeadAuthor and basic properties
                var headAuthor = new HeadAuthor
                {
                    UserName = "HeadAuthor",
                    Email = "HeadAuthor@gmail.com",
                    ViewsPerMonth = 0,
                    AuthorsHired = 0,
                    AuthorsLetGo = 0
                };
                // String variable for password
                string password = "password";

                // Use roleUserManager and passing the new instance and password, create User with variable headAuth
                var headAuth = roleUserManager.Create(headAuthor, password);

                // Check if user-creation is successful,
                if (headAuth.Succeeded)
                {
                    // If it is successful, add new User to role.
                    roleUserManager.AddToRole(headAuthor.Id, "HeadAuthor");
                }
            }
        }
    }
}