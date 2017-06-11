using System;
using System.Collections.Generic;
using System.Text;
using RazorWebModule.Views;
using RazorWebModule.Util;

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

        private Dictionary<string, View> views;

        /// <summary>
        /// protected constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayname"></param>
        public Module(string name, string displayname)
        {
            this.Name = name;
            this.DisplayName = displayname;
        }

        /// <summary>
        /// Add view
        /// </summary>
        /// <param name="view"></param>
        public void AddView(View view)
        {
            views.Add(view.Name, view);
        }
    }
}
