using System;
using System.Collections.Generic;
using System.Linq;
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
                else if (!AccessValidate(System.Web.Security.Roles.GetRolesForUser(), controllerFullName, actionName))
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
            catch (Exception)
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
        private bool AccessValidate(string[] role, string controller, string action)
        {
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
                case "CrossFileSplit":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "Home":
                    isAllowed = true;
                    break;
                case "Item":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail") || role.Contains("Operador"))
                        isAllowed = true;
                    break;
                case "Log":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "MailTest":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "ObjectType":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "Parameter":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "Process":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail") || role.Contains("Operador"))
                        isAllowed = true;
                    break;
                case "Product":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "Reports":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail") || role.Contains("Consulta")
                        || (role.Contains("Consulta Básica") && action.Contains("HistoricalFilter")))
                        isAllowed = true;
                    break;
                case "Smtp":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "Pop3":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "State":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail") || role.Contains("Operador") || role.Contains("Verificador"))
                        isAllowed = true;
                    break;
                case "Subject":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
                case "User":
                    if (role.Contains("Administrador") || role.Contains("AdministradorMail"))
                        isAllowed = true;
                    break;
            }

            return isAllowed;
        }
    }
}