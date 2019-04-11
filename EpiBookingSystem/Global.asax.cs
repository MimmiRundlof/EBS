using System.Web.Mvc;
using System.Web.Routing;

namespace EpiBookingSystem
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var routes = RouteTable.Routes;
            routes.MapRoute(
                "Default",                                              
                "{controller}/{action}/{id}",                           
                new { controller = "Account", action = "LogIn", id = "" }
            );

            RegisterRoutes(routes);
           
        }
    }
}