using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using RazorWebModule.Util;

namespace RazorWebModule
{
    /// <summary>
    /// Abstract controller for modules
    /// </summary>
    public abstract class ModuleController : Controller
    {
        /// <summary>
        /// Module registry, holds all modules
        /// </summary>
        public static Registry<Module> ModuleRegistry { get; internal set; }

        /// <summary>
        /// State to check if the modules have been initiated
        /// </summary>
        private static bool initiated = false;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public ModuleController()
        {
            // Initiates modules on the first time
            if (!initiated)
            {
                ModuleRegistry = new Registry<Module>();
                InitModules();
                initiated = true;
            }
        }

        public abstract void InitModules();
        /// <summary>
        /// Gets a view from a module
        /// </summary>
        /// <param name="moduleName">name of module</param>
        /// <param name="viewName">name of the view</param>
        /// <returns>rendered view in html code</returns>
        public virtual ActionResult GetView(string moduleName, string viewName)
        {
            // Gets module
            Module module = ModuleRegistry.Get(moduleName);

            if (module == null)
            {
                return Content("404 module not found: " + moduleName);
            }

            // Tries to get the view with name from module
            string result = module.GetView(viewName);

            if (result == null)
            {
                return Content("404 view not found: " + viewName);
            }

            // Return response
            return Content(result);
        }

        /// <summary>
        /// Gets a component
        /// </summary>
        /// <param name="moduleName">module name</param>
        /// <param name="viewName">view name</param>
        /// <param name="componentName">component name</param>
        /// <returns>returns a rendered component</returns>
        public virtual ActionResult GetComponent(string moduleName, string viewName, string componentName)
        {
            // Gets module
            Module module = ModuleRegistry.Get(moduleName);

            if (module == null)
            {
                return Content("404 module not found: " + moduleName);
            }

            // Tries to get the view with name from module
            string component = module.GetComponent(viewName, componentName);

            if (component == null)
            {
                return Content("404 component not found: " + componentName);
            }

            // Return response
            return Content(component);
        }
    }
}
