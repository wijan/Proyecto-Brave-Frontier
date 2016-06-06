using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Projecte_Final.Models;

[assembly: OwinStartupAttribute(typeof(Projecte_Final.Startup))]
namespace Projecte_Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        public void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            

            //Si en arrencar l'app no existeix l'usuari Root (que només seré jo) farem els següents passos.
            if (!roleManager.RoleExists("Root"))
            {

                // Primer creem el rol Root 
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Root";
                roleManager.Create(role);

                //I després creem l'usuari.             

                var user = new ApplicationUser();
                user.UserName = "WdWilson";
                user.Email = "wiji180892@gmail.com";

                string userPWD = "gusesgay";

                var chkUser = UserManager.Create(user, userPWD);

                //I si tot ha anat correctament li assigem el rol Root.  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Root");

                }
            }

            // També crearé el rol Admin si no existeix
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }

            // I el mateix per a l'usuari Basic
            if (!roleManager.RoleExists("Basic"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Basic";
                roleManager.Create(role);

            }
        }
    }
}

