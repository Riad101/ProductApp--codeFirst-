using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using EntityFramework_App.Identity;

[assembly: OwinStartup(typeof(EntityFramework_App.Startup))]

namespace EntityFramework_App
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login")});
            this.CreateRolesAndUsers();
        }
        public void CreateRolesAndUsers()
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);

            //creating admin
            if (!RoleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                RoleManager.Create(role);
            }
            
            //creating AdminUser

            if (userManager.FindByName("Admin") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";
                string userPassword = "admin123";

                var chkUser = userManager.Create(user, userPassword);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }


            //creating Manager role
            if (!RoleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                RoleManager.Create(role);
            }

            //creating ManagerUser

            if (!RoleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                RoleManager.Create(role);
            }
            //creating Manager user

            if (userManager.FindByName("Manager") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "Manager";
                user.Email = "manager@gmail.com";
                string userPassword = "manager123";

                var chkUser = userManager.Create(user, userPassword);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

            //creating Customer role

            if (!RoleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                RoleManager.Create(role);
            }



        }
    }
}
