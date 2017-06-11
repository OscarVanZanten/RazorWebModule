using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RazorWebModule
{
    /// <summary>
    /// Abstract controller for modules
    /// </summary>
    public abstract class ModuleController : Controller
    {
        protected abstract Module Module { get; }


        // Returns view with specific data
        public virtual ActionResult GetView(string name)
        {
            // Tries to get the view with name from module
            string view = Module.GetView(name);

            // Checks if view does exist
            if (view == null)
            {
                // Return error and name
                return Content("404 view not found: " + name);
            }

            // Return response
            return Content(view);
        }

        // Returns the component with specific data
        public virtual ActionResult GetComponent(string viewName, string componentName)
        {
            // Tries to get the view with name from module
            string component = Module.GetComponent(viewName, componentName);

            // Checks if component does exist
            if (component == null)
            {
                // Return error and name
                return Content("404 component not found: " + componentName);
            }

            // Return response
            return Content(component);
        }
    }
}
