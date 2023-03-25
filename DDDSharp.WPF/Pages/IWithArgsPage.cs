using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DDDSharp.WPF.Pages
{
    public interface IWithArgsPage<TArgs>
    {
        Window Load(TArgs args);
    }
    public interface IWithArgsPage<TArgs, TResult>
        : IWithArgsPage<TArgs>
    {
        TResult GetResult();
    }
}
