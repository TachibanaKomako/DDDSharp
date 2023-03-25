using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DDDSharp.WPF.Elements
{
    public interface IElement
    {
        UIElement Load();
    }
}
