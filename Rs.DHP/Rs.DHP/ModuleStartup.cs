using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rs.DCV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.DHP
{
    public class ModuleStartup
    {
        private readonly IEnumerable<IModule> _modules;
        private readonly IConfiguration _configuration;

        public ModuleStartup(IConfiguration configuration)
        {
            this._configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            ModulesOptions options = configuration.Get<ModulesOptions>();
            this._modules = options.Modules.Select(s => {
                Type type = Type.GetType($"{s.Type}.MoudleInjector,{s.Type}");
                if (type == null)
                {
                    Console.WriteLine($"不能导入{s.Type}", Color.Red);
                    return null;
                }
                else
                {
                    IModule module = (IModule)Activator.CreateInstance(type);
                    return module;
                }
            });
        }

        public void ConfigureServices(IServiceCollection service)
        {
            foreach (IModule module in this._modules)
            {
                if (module == null) continue;
                module.ConfigureServices(service, this._configuration);
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            //this is my first test.
            foreach (IModule module in this._modules)
            {
                module.Configure(app);
            }
        }
    }
}
