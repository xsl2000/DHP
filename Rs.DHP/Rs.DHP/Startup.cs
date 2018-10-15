using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Rs.DHP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
             Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddCors();
            var mvcbuilder = services.AddMvc(option => { option.RespectBrowserAcceptHeader = true; })
                .AddJsonOptions(option=> {
                    option.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.Use(async (context, next) => {
                string token = context.Request.Headers["Authorization"];
                if(!string.IsNullOrWhiteSpace(token) && (token=token.Split(' ').Last()).Length == 32)
                {
                    var config = (IConfiguration)AppDomain.CurrentDomain.GetData("Configuration");
                    context.Request.Headers["Authorization"] = token;
                }
                await next.Invoke();
            });
            app.UseAuthentication();
            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            AppDomain.CurrentDomain.SetData("DataPath", Path.Combine(env.ContentRootPath, "DataPath"));
            AppDomain.CurrentDomain.SetData("Configuration", Configuration);
            AppDomain.CurrentDomain.SetData("ContentRootPath", env.ContentRootPath);
        }
    }
}
