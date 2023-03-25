using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DDDSharp.WPF.Pages.Components.PageOpeners
{
    internal class PageOpener : PageOpenerBase
    {
        private readonly IPage page;
        private readonly Action? closedCallback;
        public PageOpener(IPage page,Action? closedCallback,IEventDispacher dispacher) : base(dispacher)
        {
            this.page = page;
            this.closedCallback = closedCallback;
        }

        protected override Window CreateCurrent()
        {
            return page.Load();
        }

        protected override void OnClosed()
        {
            closedCallback?.Invoke();
        }
    }
    internal class PageOpener<TResult> : PageOpenerBase
    {
        private readonly IPage<TResult> page;
        private readonly Action<TResult> closedCallback;
        public PageOpener(IPage<TResult> page, Action<TResult> closedCallback, IEventDispacher dispacher) : base(dispacher)
        {
            this.page = page;
            this.closedCallback = closedCallback;
        }

        protected override Window CreateCurrent()
        {
            return page.Load();
        }

        protected override void OnClosed()
        {
            closedCallback(page.GetResult());
        }
    }
}
