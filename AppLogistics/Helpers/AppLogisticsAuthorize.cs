using AppLogistics.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppLogistics.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AppLogisticsAuthorize : AuthorizeAttribute
    {
        
        /// <summary>
        /// Evento llamado cuando la autorización ocurre
        /// </summary>
        /// <param name="filterContext">Información sobre la solicitud y acción actuales</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Recommended way to access controller and action names
            string controllerFullName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;

            try
            {

                // Obligar a que todos estén autenticados...
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                    return;
                }
                else if (!AccessValidate(filterContext.HttpContext.User.Identity.Name, controllerFullName, actionName))
                {
                    var url = new UrlHelper(filterContext.RequestContext);
                    var accessDenied = url.Action("AccessDenied", "Home", null);
                    filterContext.Result = new RedirectResult(accessDenied);
                    // TODO: Escribir en el log
                    /*
                    try
                    {
                        string msg = string.Format(". Página: {0}\\{1}", controllerFullName, actionName);
                        Paradoc.Logging.DataBaseLog PrivDbLog = new Paradoc.Logging.DataBaseLog(ConfigurationManager.ConnectionStrings["ParadocMailWebConnectionString"].ConnectionString);
                        PrivDbLog.DoLog(Paradoc.Logging.LogType.Auditoria, System.Diagnostics.TraceEventType.Warning, Properties.Resources.Log_User_AccessDenied + msg, filterContext.HttpContext.User.Identity.Name);
                    }
                    catch { }
                    */
                    return;
                }
                else
                {
                    base.OnAuthorization(filterContext);
                }
            }
            catch (Exception ex)
            {
                //TODO: log error

                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

        }

        /// <summary>
        /// Valida si el controlador y/o la acción permiten la ejecución para un conjunto de roles
        /// </summary>
        /// <param name="role">Roles del usuario</param>
        /// <param name="controller">Controlador al que se intenta acceder</param>
        /// <param name="action">Acción que se intenta ejecutar</param>
        /// <returns></returns>
        private bool AccessValidate(string userName, string controller, string action)
        {
            List<string> role = GetUserRoles(userName);

            bool isAllowed = false;
            switch (controller)
            {
                case "Account":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "Activities":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "AFPs":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                    /*
                case "BranchOffices":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                    */
                case "Carriers":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "ClientAreas":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "Clients":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "Employees":
                    if (role.Contains("Administrador") || role.Contains("Supervisor") || role.Contains("Operario"))
                        isAllowed = true;
                    break;
                case "EPS":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "Manage":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "MaritalStatus":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "Products":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "Rates":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "Services":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;
                case "VehicleTypes":
                    if (role.Contains("Administrador") || role.Contains("Supervisor"))
                        isAllowed = true;
                    break;

            }

            return isAllowed;
        }



        private List<string> GetUserRoles(string userName)
        {
            ApplicationDbContext context = ApplicationDbContext.Create();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var roles = userManager.GetRolesAsync(user.Id);

            return roles.Result.ToList();
        }
    }
}