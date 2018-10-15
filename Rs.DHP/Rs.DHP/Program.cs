using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Rs.DHP
{
    public class Program
    {
        static private string m_configFileName = "Configs";
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                string dir = Path.GetFullPath(env.ContentRootPath);
                string settingsFolder = Path.Combine(dir, m_configFileName);
                if (!Directory.Exists(settingsFolder))
                {
                    Directory.CreateDirectory(settingsFolder);
                    dir = Path.GetFullPath(env.ContentRootPath + "/..");
                }
                //settingsFolder = Path.Combine(dir, m_configFileName);
                //if (!Directory.Exists(settingsFolder))
                //    dir = Path.GetFullPath(env.ContentRootPath + "/bin");
                //settingsFolder = Path.Combine(dir, m_configFileName);
                Console.WriteLine($"Read Config files from {settingsFolder}");
                var configs = Directory.GetFiles(settingsFolder, "*.json");
                if (configs != null && configs.ToList().Count > 0)
                    configs.ToList().ForEach(p => { config.AddJsonFile(p, optional: false, reloadOnChange: true); });
            })
            .UseUrls("http://0.0.0.0:8091")
            .UseStartup<Startup>()
            .Build();
    }
}
