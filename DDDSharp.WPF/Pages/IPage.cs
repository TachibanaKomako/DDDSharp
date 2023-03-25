using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DDDSharp.WPF.Pages
{
    public interface IPage
    {
        Window Load();
    }
    public interface IPage<T> : IPage
    {
        T GetResult();
    }
}
