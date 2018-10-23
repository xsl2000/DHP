using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.DCV
{
    /// <summary>
    /// Represents a configurable module containing multiple servies.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Configurates the module services.
        /// </summary>
        /// <param name="services">
        /// Instance of <see cref="IServiceCollection"/>
        /// </param>
        /// <param name="configuration">
        /// Instance of <see cref="IConfiguration"/>
        /// </param>
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
        /// <summary>
        /// Configures module services.
        /// </summary>
        /// <param name="app">
        /// Instance of <see cref="IApplicationBuilder"/>
        /// </param>
        void Configure(IApplicationBuilder app);
    }
}
