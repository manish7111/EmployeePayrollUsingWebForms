using EmployeeManagementBL;
using EmployeeManagementDAL;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Unity;

namespace EmployeeManagementPayrollSystem
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            IUnityContainer container = this.AddUnity();

            container.RegisterType<IEmployeeRepo, EmployeeRepo>();
            container.RegisterType<IEmployeeBL, EmployeeBL>();
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}