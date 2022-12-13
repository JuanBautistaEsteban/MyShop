using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using MyShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using MyShop.CORE;

namespace MyShop.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Implementación de seguridad por Roles y Carpetas
            //Obtenemos los contextos de usuarios y BBDD
            ApplicationDbContext contextDB = new ApplicationDbContext();
            RoleManager<IdentityRole> RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(contextDB));

            UserManager <ApplicationUser > UserManager = new UserManager<ApplicationUser> (new UserStore <ApplicationUser>(contextDB));

            #region Creación de roles
            if(!RoleManager .RoleExists("Admin"))
            {
                RoleManager.Create(new IdentityRole("Admin"));
            }

            if (!RoleManager .RoleExists("Client"))
            {
                RoleManager.Create(new IdentityRole("Client"));
            }
            #endregion

            #region Crear un primer usuario con el rol de Administrador
            ApplicationUser user = UserManager.FindByName("admin@admin.es");
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "admin@admin.es";
                user.Email = "admin@admin.es";
                IdentityResult result = UserManager.Create(user, "Centollos1234@");
                if (!result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
                else
                {
                    throw new Exception("Usuario no creado.");
                }
            }
            else
            {
                //El usuario está creado pero, ¿Ya tiene el rol de administrador?
                if (!UserManager.IsInRole(user.Id, "Admin"))
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }

            #endregion




        }
    }
}