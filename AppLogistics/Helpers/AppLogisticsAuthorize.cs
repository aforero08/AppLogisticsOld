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
            List<string> role = getUserRoles(userName);

            bool isAllowed = false;
            switch (controller)
            {
                case "Account":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "Attachment":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail") || role.Contains("Operador"))
                        isAllowed = true;
                    break;
                case "BillTemplate":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "BodyTemplate":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "BodyTemplateCondition":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "Client":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail") || role.Contains("Consulta")
                        || (role.Contains("Consulta Básica") && action.Contains("Search"))
                        || (role.Contains("Consulta Básica") && action.Contains("Details"))
                        || (role.Contains("Consulta Básica") && action.Contains("Create"))
                        || (role.Contains("Consulta Básica") && action.Contains("Edit"))
                        || (role.Contains("Consulta Básica") && action.Contains("Search")))
                        isAllowed = true;
                    break;
                
            }

            return isAllowed;
        }



        private List<string> getUserRoles(string userName)
        {
            ApplicationDbContext context = ApplicationDbContext.Create();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var roles = userManager.GetRolesAsync(user.Id);

            return roles.Result.ToList();
        }
    }
}