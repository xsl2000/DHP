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
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostcontent, config) => {
                //添加相应的配置文件
            var env = hostcontent.HostingEnvironment;
            string dir = Path.GetFullPath(env.ContentRootPath);
            string Folder = Path.Combine(dir, "Configs");
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);

            }
            Console.WriteLine($"Read Config files from {Folder}");
            var configs = Directory.GetFiles("Configs", "*.json");
            if (configs != null && configs.ToList().Count > 0)
                configs.ToList().ForEach(p => { config.AddJsonFile(p, optional: false, reloadOnChange: true); });
            })
            .UseStartup<Startup>();
    }
}
