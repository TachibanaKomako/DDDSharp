using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DDDSharp.WPF.Pages.Events
{
    internal class ActivePageEventSubscriber : IEventSubscriber<ActivePageEvent>
    {
        private readonly Window page;
        public ActivePageEventSubscriber(Window page)
        {
            this.page = page;
        }

        public void Handle(ActivePageEvent args)
        {
            if (page.IsActive)
            {
                args.ChangePage(page);
            }
        }
    }
}
