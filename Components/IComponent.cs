using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorWebModule.Components
{
    /// <summary>
    /// Blueprint for components, used mainly to refer to components without using the model type
    /// </summary>
    public interface IComponent
    {
        string Name { get; }
        string Compile();
    }
}
