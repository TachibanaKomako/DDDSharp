using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DDDSharp.WPF.Pages.Events
{
    internal class ActivePageEvent
    {
        private Window? page;
        public bool IsEmpty => page is null;
        public Window Page => page ?? throw new ArgumentNullException(nameof(page));

        public void ChangePage(Window page)
        {
            this.page = page;
        }
    }
}
