using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MeuMedico.Filtros
{
    public class LoginFiltroAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuarioLogadoID"];
            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                            new { controller = "Home", action = "Login" }
                        )
                );
            }

            base.OnActionExecuting(filterContext);
        }
    }
}