using System;
using System.Collections.Generic;
using System.Text;

using RazorWebModule.Util;

namespace RazorWebModule
{
    /// <summary>
    /// Module class represeting a list of razor views
    /// </summary>
    public class Module
    {
        /// <summary>
        /// Registry that keeps count of the modules
        /// </summary>
        public static Registry<Module> Registry { get { if (registry == null) { registry = new Registry<Module>(); } return registry; } set { registry = value; } }
        private static Registry<Module> registry;

        /// <summary>
        /// Module name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// DisplayName for a module
        /// </summary>
        public string DisplayName { get; internal set; }



    }
}
