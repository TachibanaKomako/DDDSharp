using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DDDSharp.WPF.Elements.Services
{
    internal class ElementService :DomainObject, IElementService
    {
        public UIElement Create<T>() where T : IElement
        {
            //新規で作成
            IElement element = Container.CreateService<T>();
            //
            return element.Load();
        }
    }
}
