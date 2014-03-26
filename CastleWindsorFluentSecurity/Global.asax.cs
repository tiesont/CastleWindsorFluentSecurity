using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Castle.Windsor;
using Castle.Windsor.Installer;

namespace CastleWindsorFluentSecurity
{
    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        private static IWindsorContainer _container;
        public IWindsorContainer Container
        {
            get { return _container; }
        }

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_Start()
        {
            BootstrapContainer();

            AreaRegistration.RegisterAllAreas();

            SecurityConfig.RegisterSecurityRules();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // NOTE: Remove the following lines if you need .aspx support
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            MvcHandler.DisableMvcResponseHeader = true;
        }

        protected void Application_End()
        {
            _container.Dispose();
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;

            Server.ClearError();

            var routeData = new RouteData();

            routeData.Values["controller"] = "Errors";
            routeData.Values["action"] = "General";
            routeData.Values["exception"] = exception;

            if (httpException != null)
            {
                var statusCode = httpException.GetHttpCode();
                switch (statusCode)
                {
                    case 401:
                        routeData.Values["action"] = "NotAuthorized";
                        break;
                    case 403:
                        routeData.Values["action"] = "Forbidden";
                        break;
                    case 404:
                        routeData.Values["action"] = "NotFound";
                        break;
                }
            }

            // Avoid IIS7 getting in the middle
            Response.TrySkipIisCustomErrors = true;

            IController errorsController = new Controllers.ErrorsController();
            HttpContextWrapper wrapper = new HttpContextWrapper(Context);

            var rc = new RequestContext(wrapper, routeData);
            errorsController.Execute(rc);
        }
    }
}