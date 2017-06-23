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
            CollectRenderData();
            ValidateRenderData();
            string result = Render();
            CleanUpRenderData();
            return result;
        }

        /// <summary>
        /// Collects all data needed for rendering
        /// </summary>
        protected abstract void CollectRenderData();

        /// <summary>
        /// Validates render data needed
        /// </summary>
        protected abstract void ValidateRenderData();

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
        protected virtual void CleanUpRenderData()
        {
            model = default(T);
            bag = new DynamicViewBag();
        }

        /// <summary>
        /// Processes a form being inputted
        /// </summary>
        /// <param name="data">Data from the form</param>
        public void ProcessForm(Dictionary<string, string> data)
        {
            CollectFormData(data);
            ValidateFormData(data);
            ExecuteFormData(data);
            CleanUpFormData(data);
        }

        /// <summary>
        /// Collects all data needed using form data
        /// </summary>
        /// <param name="data">Data from the form</param>
        protected virtual void CollectFormData(Dictionary<string, string> data) { }

        /// <summary>
        /// Validates form data needed
        /// </summary>
        /// <param name="data">Data from the form</param>
        protected virtual void ValidateFormData(Dictionary<string, string> data) { }

        /// <summary>
        /// Executes and applies the data collected through the form
        /// </summary>
        /// <param name="data">Data from the form</param>
        protected virtual void ExecuteFormData(Dictionary<string, string> data) { }

        /// <summary>
        /// Cleans up all data gained from the form
        /// </summary>
        /// <param name="data">Data from the form</param>
        protected virtual void CleanUpFormData(Dictionary<string, string> data) { }
    }
}
