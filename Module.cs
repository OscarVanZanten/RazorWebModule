using System;
using System.Collections.Generic;
using System.Text;
using RazorWebModule.Views;
using RazorWebModule.Util;
using RazorWebModule.Components;

namespace RazorWebModule
{
    /// <summary>
    /// Module class represeting a list of razor views
    /// </summary>
    public class Module
    {
        /// <summary>
        /// Module name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// DisplayName for a module
        /// </summary>
        public string DisplayName { get; internal set; }

        public Dictionary<string, View> Views { get; internal set; }

        /// <summary>
        /// protected constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayname"></param>
        public Module(string name, string displayname)
        {
            this.Name = name;
            this.DisplayName = displayname;
            this.Views = new Dictionary<string, View>();
        }

        /// <summary>
        /// Add view
        /// </summary>
        /// <param name="view"></param>
        public void AddView(View view)
        {
            Views.Add(view.Name, view);
        }

        /// <summary>
        /// gets the rendered view
        /// </summary>
        /// <param name="name">name of view</param>
        /// <returns>rendered view</returns>
        public View GetView(string name)
        {
            View view = null;
            Views.TryGetValue(name, out view);
            return view;
        }

        /// <summary>
        /// Gets the renedered compoennt
        /// </summary>
        /// <param name="viewName">name of the view</param>
        /// <param name="componentName">name of the component</param>
        /// <returns>rendred component</returns>
        public IComponent GetComponent(string viewName, string componentName)
        {
            View view = null;
            Views.TryGetValue(viewName, out view);
            IComponent component = null;
            if (view != null)
            {
                component = view.GetComponent(componentName, view.RootComponent).Component;
            }
            return component;
        }
    }
}
