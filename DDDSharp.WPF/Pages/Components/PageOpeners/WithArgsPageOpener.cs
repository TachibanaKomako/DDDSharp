using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DDDSharp.WPF.Pages.Components.PageOpeners
{
    internal class WithArgsPageOpener<TArgs> : PageOpenerBase
    {
        private readonly TArgs args;
        private readonly IWithArgsPage<TArgs> page;
        private readonly Action? closedCallback;
        public WithArgsPageOpener(IWithArgsPage<TArgs> page,TArgs args, Action? closedCallback, IEventDispacher dispacher) : base(dispacher)
        {
            this.page = page;
            this.args = args;
            this.closedCallback = closedCallback;
        }

        protected override Window CreateCurrent()
        {
            return page.Load(args);
        }

        protected override void OnClosed()
        {
            closedCallback?.Invoke();
        }
    }


    internal class WithArgsPageOpener<TArgs,TResult> : PageOpenerBase
    {
        private readonly TArgs args;
        private readonly IWithArgsPage<TArgs,TResult> page;
        private readonly Action<TResult> closedCallback;
        public WithArgsPageOpener(IWithArgsPage<TArgs,TResult> page, TArgs args, Action<TResult> closedCallback, IEventDispacher dispacher) : base(dispacher)
        {
            this.page = page;
            this.args = args;
            this.closedCallback = closedCallback;
        }

        protected override Window CreateCurrent()
        {
            return page.Load(args);
        }

        protected override void OnClosed()
        {
            closedCallback(page.GetResult());
        }
    }
}
