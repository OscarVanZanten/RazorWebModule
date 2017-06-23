using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using RazorWebModule.Util;
using RazorWebModule.Components;
using RazorWebModule.Views;

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
        public ContentResult GetView(string moduleName, string viewName)
        {
            // Gets module
            Module module = ModuleRegistry.Get(moduleName);

            if (module == null)
            {
                return Content("404 module not found: " + moduleName);
            }

            // Tries to get the view with name from module
            View view = module.GetView(viewName);

            if (view == null)
            {
                return Content("404 view not found: " + viewName);
            }

            // Return response
            return Content(view.Render());
        }

        /// <summary>
        /// Gets a component
        /// </summary>
        /// <param name="moduleName">module name</param>
        /// <param name="viewName">view name</param>
        /// <param name="componentName">component name</param>
        /// <returns>returns a rendered component</returns>
        public ContentResult GetComponent(string moduleName, string viewName, string componentName)
        {
            // Gets module
            Module module = ModuleRegistry.Get(moduleName);

            if (module == null)
            {
                return Content("404 module not found: " + moduleName);
            }

            // Tries to get the view with name from module
            IComponent component = module.GetComponent(viewName, componentName);

            if (component == null)
            {
                return Content("404 component not found: " + componentName);
            }

            // Return response
            return Content(component.Compile());
        }

        /// <summary>
        /// Submits a form to a specific component
        /// </summary>
        /// <param name="moduleName">module name</param>
        /// <param name="viewName">view name</param>
        /// <param name="componentName">component name</param>
        /// <param name="data">data from the form</param>
        /// <returns>Status result</returns>
        public JsonResult SubmitComponentForm(string moduleName, string viewName, string componentName, Dictionary<string, string> data)
        {
            // Gets module
            Module module = ModuleRegistry.Get(moduleName);

            if (module == null)
            {
                return Json("404 module not found: " + moduleName);
            }

            IComponent component = module.GetComponent(viewName, componentName);

            if (component == null)
            {
                return Json("404 component not found: " + componentName);
            }

            component.ProcessForm(data);

            return Json("204 succes");
        }
    }
}
