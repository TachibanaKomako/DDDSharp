using DDDSharp.Events;
using DDDSharp.WPF.Pages.Components.PageOpeners;
using DDDSharp.WPF.Pages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSharp.WPF.Pages.Services
{
    public class PageService : DomainObject, IPageService
    {
        private static readonly IEventDispacher dispacher = new EventDispacher();
        public void ClosePage()
        {
            //アクティブなページを取得
            ActivePageEvent activePageEvent = new();
            dispacher.Publish(activePageEvent);
            //アクティブなページが存在すれば、Close
            if(activePageEvent.IsEmpty is false)
            {
                activePageEvent.Page.Close();
            }
        }

        public void OpenPage<TPage>() where TPage : IPage
        {
            //新規でTPageを作成する
            IPage page = Container.CreateService<TPage>();
            //PageOpenerを作成する
            PageOpenerBase opener = new PageOpener(page, null, dispacher);
            //Pageを開く
            OpenPage(opener);
        }

        public void OpenPage<TPage>(Action closedCallback) where TPage : IPage
        {
            //新規でTPageを作成する
            IPage page = Container.CreateService<TPage>();
            //PageOpenerを作成する
            PageOpenerBase opener = new PageOpener(page, closedCallback, dispacher);
            //Pageを開く
            OpenPage(opener);
        }

        public void OpenPage<TPage, TResult>(Action<TResult> closedCallback) where TPage : IPage<TResult>
        {
            //新規でTPageを作成する
            IPage<TResult> page = Container.CreateService<TPage>();
            //PageOpenerを作成する
            PageOpenerBase opener = new PageOpener<TResult>(page, closedCallback, dispacher);
            //Pageを開く
            OpenPage(opener);
        }

        public void OpenPage<TPage, TArgs>(TArgs args) where TPage : IWithArgsPage<TArgs>
        {
            //新規でTPageを作成する
            IWithArgsPage<TArgs> page = Container.CreateService<TPage>();
            //PageOpenerを作成する
            PageOpenerBase opener = new WithArgsPageOpener<TArgs>(page, args,null, dispacher);
            //Pageを開く
            OpenPage(opener);
        }

        public void OpenPage<TPage, TArgs>(TArgs args, Action closedCallback) where TPage : IWithArgsPage<TArgs>
        {
            //新規でTPageを作成する
            IWithArgsPage<TArgs> page = Container.CreateService<TPage>();
            //PageOpenerを作成する
            PageOpenerBase opener = new WithArgsPageOpener<TArgs>(page, args, closedCallback, dispacher);
            //Pageを開く
            OpenPage(opener);
        }

        public void OpenPage<TPage, TArgs, TResult>(TArgs args, Action<TResult> closedCallback) where TPage : IWithArgsPage<TArgs, TResult>
        {
            //新規でTPageを作成する
            IWithArgsPage<TArgs,TResult> page = Container.CreateService<TPage>();
            //PageOpenerを作成する
            PageOpenerBase opener = new WithArgsPageOpener<TArgs,TResult>(page, args, closedCallback, dispacher);
            //Pageを開く
            OpenPage(opener);
        }

        private static void OpenPage(PageOpenerBase pageOpener)
        {
            pageOpener.Open();
        }
    }
}
