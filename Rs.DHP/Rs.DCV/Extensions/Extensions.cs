using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.DCV.Extensions
{
    /// <summary>
    /// 护展类
    /// </summary>
    static public class Extensions
    {
        static public DcvBuilder AddDcv(this IServiceCollection services,Action<DcvOptions>setupAction)
        {
            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));
            //services.AddMvc().AddRazorPagesOptions(option => option.Conventions.AddPageRoute("/Dashbord/Pages","Dashbord"));
            return new DcvBuilder(services);
        }

        static public IApplicationBuilder UseDcv(this IApplicationBuilder app, Action<DcvOptions> setupAction=null)
        {
            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "Dashbord", template: "/Dashbord/Pages");
            });
            //app.UseMvc(routes => {
            //    app.ApplicationServices.GetService<IRouteProvider>().GetRoutes().OrderByDescending(route => route.Priority).Each(route =>
            //    {
            //        routes.MapRoute(route.RouteName, route.Template, route.Defaults, route.Constraints, route.DataTokens);
            //    });
            //});
            return app;            
        }

        static public DcvOptions UseDashboard(this DcvOptions dcvoptions)
        {
            return dcvoptions.UseDashboard(opt => { });
        }

        static public DcvOptions UseDashboard(this DcvOptions dcvoptions,Action<DashboardOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return dcvoptions;
        }
    }
}
