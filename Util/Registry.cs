using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorWebModule.Util
{
    /// <summary>
    /// registry for holding data
    /// </summary>
    /// <typeparam name="T">type of said data</typeparam>
    public class Registry<T>
    {
        /// <summary>
        /// Items held
        /// </summary>
        Dictionary<string, T> items;

        /// <summary>
        /// Constructor
        /// </summary>
        public Registry()
        {
            items = new Dictionary<string, T>();
        }

        /// <summary>
        /// Add entry
        /// </summary>
        /// <param name="name">name of entry</param>
        /// <param name="value">value of entry</param>
        public void Add(string name, T value)
        {
            items.Add(name, value);
        }

        /// <summary>
        /// Try to get value by name
        /// </summary>
        /// <param name="name">name of entry being searched</param>
        /// <returns>value</returns>
        public T Get(string name)
        {
            T result = default(T);
            items.TryGetValue(name, out result);
            return result;
        }

    }
}
