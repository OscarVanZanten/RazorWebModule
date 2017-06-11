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
        public static Registry<Module> ModuleRegistry = new Registry<Module>();

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
