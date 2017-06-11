using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorWebModule.Components
{
    /// <summary>
    /// Container that holds a list of component containers and renders this
    /// </summary>
    public class ComponentContainerGroup : IComponentContainer
    {
        /// <summary>
        /// List of components
        /// </summary>
        public List<IComponentContainer> Components { get; internal set; }
        public string Name { get; internal set; }

        /// <summary>
        /// constructors
        /// </summary>
        public ComponentContainerGroup(string name) : this(name, new List<IComponentContainer>()) { }
        public ComponentContainerGroup(string name, List<IComponentContainer> components)
        {
            this.Components = components;
            this.Name = name;
        }

        /// <summary>
        /// adds a component to the list
        /// </summary>
        /// <param name="component">component to be added</param>
        public void AddComponent(IComponentContainer component)
        {
            Components.Add(component);
        }

        /// <summary>
        /// renders the components
        /// </summary>
        /// <returns>row filled with components</returns>
        public string Render()
        {
            // Start row
            string divStart = "<div class=\"row-fluid\">";

            // End row
            string divEnd = "</div>";

            // Html as result
            string html = divStart;

            // Cycles through all components
            foreach (IComponentContainer component in Components)
            {
                // Render component and add it the html
                html += component.Render();
            }
            // finish div tag
            html += divEnd;

            return html;
        }
    }
}
