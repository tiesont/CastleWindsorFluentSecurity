using System.Web;
using System.Web.Mvc;

namespace CastleWindsorFluentSecurity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new FluentSecurity.HandleSecurityAttribute(), 0);

            /*
             * This is the default error filter - uncomment it if you remove FluentSecurity
             * 
             * filters.Add(new HandleErrorAttribute());
             */
        }
    }
}