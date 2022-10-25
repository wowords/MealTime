using System.Web;
namespace MealTime.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(null, "", new
                {
                    controller = "home",
                    action = ""
                });

            }
       );
        }
    }
}
