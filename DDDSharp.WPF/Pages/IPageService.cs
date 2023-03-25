using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp.WPF.Pages
{
    public interface IPageService
    {
        void OpenPage<TPage>() where TPage : IPage;
        void OpenPage<TPage>(Action closedCallback) where TPage : IPage;
        void OpenPage<TPage, TResult>(Action<TResult> closedCallback) where TPage : IPage<TResult>;

        void OpenPage<TPage, TArgs>(TArgs args) where TPage : IWithArgsPage<TArgs>;
        void OpenPage<TPage, TArgs>(TArgs args, Action closedCallback) where TPage : IWithArgsPage<TArgs>;
        void OpenPage<TPage, TArgs, TResult>(TArgs args, Action<TResult> closedCallback) where TPage : IWithArgsPage<TArgs, TResult>;
        void ClosePage();
    }
}
