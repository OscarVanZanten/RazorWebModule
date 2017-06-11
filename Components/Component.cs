using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RazorModule.Components
{
    /// <summary>
    /// Basic Component
    /// </summary>
    class Component
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
        private string file;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">name of the component</param>
        /// <param name="url">url of the file</param>
        public Component(string name, string url)
        {
            this.Name = name;
            this.path = url;
            this.file = File.ReadAllText(this.path);
        }



    }
}
