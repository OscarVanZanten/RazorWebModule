using System;
using System.Collections.Generic;
using System.Text;

using RazorWebModule.Components;

namespace RazorWebModule.Views
{
    /// <summary>
    /// RazorView
    /// </summary>
    public class View
    {
        /// <summary>
        /// Name of the view
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// DisplayName of the view
        /// </summary>
        public string DisplayName { get; internal set; }

        /// <summary>
        /// The root of component tree
        /// </summary>
        public ComponentContainerGroup RootComponent { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">name of the view</param>
        /// <param name="displayname">displayname of the view</param>
        public View(string name, string displayname)
        {
            this.Name = name;
            this.DisplayName = displayname;
            this.RootComponent = new ComponentContainerGroup("Root");
        }

        /// <summary>
        /// renders view through the component tree
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            return RootComponent.Render();
        }

        /// <summary>
        /// gets component with name from a root node
        /// </summary>
        /// <param name="name"></param>
        /// <param name="component"></param>
        /// <returns>return compont</returns>
        public IComponentContainer GetComponent(string name, IComponentContainer component)
        {
            if (component.Name == name)
            {
                return component;
            }
            if (component is ComponentContainerGroup)
            {
                ComponentContainerGroup group = (ComponentContainerGroup)component;
                foreach (IComponentContainer container in group.Components)
                {
                    IComponentContainer found = GetComponent(name, container);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }
            return null;
        }
    }
}
