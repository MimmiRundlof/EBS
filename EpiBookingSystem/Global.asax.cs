using System.Web.Mvc;
using System.Web.Routing;

namespace EpiBookingSystem
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ////UnityConfig.RegisterTypes(UnityConfig.Container);
            ///


            var routes = RouteTable.Routes;
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Account", action = "Index", id = "" }  // Parameter defaults
            );

            RegisterRoutes(routes);
            //    //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }
    }
}