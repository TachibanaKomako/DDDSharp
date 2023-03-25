using DDDSharp.WPF.Elements;
using DDDSharp.WPF.Elements.Services;
using DDDSharp.WPF.Pages;
using DDDSharp.WPF.Pages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp.WPF
{
    public class WPFDependencySetup : IDependencySetup
    {
        public void Run(IServiceContainerBuilder builder)
        {
            builder.AddService<IElementService, ElementService>();
            builder.AddService<IPageService, PageService>();
        }
    }
}
