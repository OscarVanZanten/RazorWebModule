using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorWebModule.Components
{
    /// <summary>
    /// BluePrint for componentcontainers, used for the composite pattern of the modules
    /// </summary>
    public interface IComponentContainer
    {
        IComponent Component { get; }
        string Name { get; }
        string Render();
    }
}
