using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Security.Claims;

namespace APIManager.Controllers
{
    public class SecurityController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var controllerName = filterContext.RouteData.Values["controller"];
            var ViewName = filterContext.RouteData.Values["action"];
            //EndpointMonitoringModel em = new EndpointMonitoringModel();
            //SqlConnection conn = em.GetConnection();
            //conn.Open();

            //SqlCommand cmd = new SqlCommand("insert into endpoint (username,reqtime,endopint_controller,endpoint_view) values((select top 1 username from aspnetusers where id='" + user + "'),CURRENT_TIMESTAMP ,'" + controllerName + "','" + ViewName + "')", conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            Log("OnActionExecuted", filterContext.RouteData);

        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }

      
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0}- controller:{1} action:{2}", methodName,
                                                                        controllerName,
                                                                        actionName);
            Debug.WriteLine(message);
        }
    }
}
