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
        static public DcvBuilder AddDcv(this IServiceCollection services)
        {
            DcvBuilder bulder = new DcvBuilder(services);
            services.AddMvc().AddRazorPagesOptions(option => option.RootDirectory = "/Dashbord");
            return bulder;
        }
    }
}
