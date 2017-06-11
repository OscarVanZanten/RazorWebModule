using RazorWebModule.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorWebModule.Components.Generic
{
    public class TextComponent : Component<Object>
    {
        public TextComponent(string name, string url) : base(name, url)
        {

        }

        protected override void CollectData()
        {

        }

        protected override void ValidateData()
        {

        }
    }
}