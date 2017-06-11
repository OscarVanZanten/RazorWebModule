using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using RazorEngine;
using RazorEngine.Templating;

namespace RazorWebModule.Components
{
    /// <summary>
    /// Basic Component
    /// </summary>
    public abstract class Component<T> : IComponent
    {
        /// <summary>
        /// Name of the component
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Path of the file used to make the component
        /// </summary>
        private string path;

        /// <summary>
        /// File loaded from path
        /// </summary>
        private string template;

        /// <summary>
        /// the data temperarily held for compiling the component
        /// </summary>
        private T model;
        private DynamicViewBag bag;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">name of the component</param>
        /// <param name="url">url of the file</param>
        public Component(string name, string url)
        {
            this.path = url;
            this.Name = url.Split('\\')[url.Split('\\').Length - 1];
            this.template = File.ReadAllText(this.path);
        }

        /// <summary>
        /// Compiles the component including collecting data, validating data, rendering and cleaning up
        /// </summary>
        /// <returns>Compiled component in string form</returns>
        public string Compile()
        {
            CollectData();
            ValidateData();
            string result = Render();
            CleanUp();
            return result;
        }

        /// <summary>
        /// Collects all data needed
        /// </summary>
        protected abstract void CollectData();

        /// <summary>
        /// Validates data needed
        /// </summary>
        protected abstract void ValidateData();

        /// <summary>
        /// Rendering the component
        /// </summary>
        /// <param name="model">the data need to render a component</param>
        /// <returns></returns>
        private string Render()
        {
            string result = null;

            if (Engine.Razor.IsTemplateCached(Name, typeof(T)))
            {
                result = Engine.Razor.Run(Name, typeof(T), model, bag);
            }
            else
            {
                result = Engine.Razor.RunCompile(template, Name, typeof(T), model, bag);
            }

            return result;
        }

        /// <summary>
        /// Cleans up the data after compiling
        /// </summary>
        private void CleanUp()
        {
            model = default(T);
            bag = new DynamicViewBag();
        }
    }
}
