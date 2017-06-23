using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorWebModule.Components
{
    /// <summary>
    /// Container that holds a component and forms its make up around it
    /// </summary>
    public class ComponentContainer : IComponentContainer
    {
        // Component
        public IComponent Component { get; internal set; }

        public string Name { get { return Component.Name; } }

        /// <summary>
        /// bootstrap offsets
        /// </summary>
        private int[] width, offset;

        /// <summary>
        /// Constructor for
        /// </summary>
        /// <param name="component"></param>
        public ComponentContainer(IComponent component, int[] width, int[] offset)
        {
            this.Component = component;
            this.width = width;
            this.offset = offset;

            if (width.Length != 4)
            {
                throw new ArgumentException("Int array width must have the length of 4");
            }

            if (offset.Length != 4)
            {
                throw new ArgumentException("Int array offset must have the length of 4");
            }
        }


        /// <summary>
        /// Renders the container
        /// </summary>
        public string Render()
        {
            string offset = "col-xs-offset-" + this.offset[0] + " " +
                            "col-sm-offset-" + this.offset[1] + " " +
                            "col-md-offset-" + this.offset[2] + " " +
                            "col-lg-offset-" + this.offset[3];

            // Width tag
            string width = "col-xs-" + this.width[0] + " " +
                            "col-sm-" + this.width[1] + " " +
                            "col-md-" + this.width[2] + " " +
                            "col-lg-" + this.width[3];

            // Div start tag
            string divStart = "<div id=\"" + Component.Name + "\" class=\"" + width + " " + offset + "\">";

            // Div end tag
            string divEnd = "</div>";

            // Html rendered from the view
            string html = divStart + " " + Component.Compile() + " " + divEnd;

            //return result
            return html;
        }
    }
}
