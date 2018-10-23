using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.DCV
{
    /// <summary>
    /// Module Host Configuration.
    /// </summary>
    public class ModulesOptions
    {
        /// <summary>
        /// Module base directory
        /// </summary>
        public string ModuleBasePath { get; set; }
        /// <summary>
        /// List of Module Configurations.
        /// </summary>
        public List<ModuleOptions> Modules { get; set; }
    }

    /// <summary>
    /// Module Configuration
    /// </summary>
    public class ModuleOptions
    {
        /// <summary>
        /// Module Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Module type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Module Path
        /// </summary>
        public string Path { get; set; }
    }
}
