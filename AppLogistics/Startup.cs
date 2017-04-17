using System;
using Microsoft.Owin;
using Owin;
using AppLogistics.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(AppLogistics.Startup))]
namespace AppLogistics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Crear roles
            ConfigureRoles();

            // Crear y configurar administrador por defecto
            CreateAdmin();
        }

        
        /// <summary>
        /// Permite crear los roles iniciales en caso de que no existan
        /// </summary>
        private void ConfigureRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Crear el rol de Administrador
            if (!roleManager.RoleExists("Administrador"))
            {
                var role = new IdentityRole();
                role.Name = "Administrador";
                roleManager.Create(role);
            }

            // Crear el rol del Supervisor
            if (!roleManager.RoleExists("Supervisor"))
            {
                var role = new IdentityRole();
                role.Name = "Supervisor";
                roleManager.Create(role);
            }

            // Crear el rol de Operario
            if (!roleManager.RoleExists("Operario"))
            {
                var role = new IdentityRole();
                role.Name = "Operario";
                roleManager.Create(role);
            }

            // Crear el rol de Visitante. Por defecto para quien solamente está registrado
            if (!roleManager.RoleExists("Visitante"))
            {
                var role = new IdentityRole();
                role.Name = "Visitante";
                roleManager.Create(role);
            }
        }


        /// <summary>
        /// Permite crear el administrador por defecto
        /// </summary>
        private void CreateAdmin()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.FindByName(ConfigurationManager.AppSettings["Users.AdminAppLogistics.Username"]) == null)
            {
                var user = new ApplicationUser();
                user.UserName = ConfigurationManager.AppSettings["Users.AdminAppLogistics.Username"];
                user.Email = ConfigurationManager.AppSettings["Users.AdminAppLogistics.Email"]; ;
                user.LockoutEnabled = true;
                user.EmailConfirmed = true;
                string userPWD = ConfigurationManager.AppSettings["Users.AdminAppLogistics.Password"]; ;

                var chkUser = userManager.Create(user, userPWD);

                // Agregar rol Administrador por defecto
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Administrador");
                }
            }
        }

    }
}
