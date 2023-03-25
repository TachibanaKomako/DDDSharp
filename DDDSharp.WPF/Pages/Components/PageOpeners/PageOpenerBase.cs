using DDDSharp.WPF.Pages.Components.OpenPages.Events;
using DDDSharp.WPF.Pages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DDDSharp.WPF.Pages.Components.PageOpeners
{
    internal abstract class PageOpenerBase
    {
        private Window? parent;
        private Window? current;
        private IEventSubscriber<ActivePageEvent>? eventSubscriber;
        private readonly IEventDispacher dispacher;
        public PageOpenerBase(IEventDispacher dispacher)
        {
            //初期設定
            this.dispacher = dispacher;
        }
        public void Open()
        {
            //2回目の呼び出しを禁止
            if(current is not null)
            {
                throw new MethodAccessException();
            }
            //Windowを作成する
            current = CreateCurrent();

            //parentを取得する
            ActivePageEvent activePageEvent = new();
            dispacher.Publish(activePageEvent);
            parent = activePageEvent.IsEmpty ? null : activePageEvent.Page;
            //イベントの追加
            current.Closed += Page_Closed;
            //アクティブイベントの作成
            eventSubscriber = new ActivePageEventSubscriber(current);
            dispacher.Subscribe(eventSubscriber);
            //ページを開く
            current.Show();

        }
        protected abstract Window CreateCurrent();
        protected abstract void OnClosed();
        private void Page_Closed(object? sender, EventArgs e)
        {
            //クローズイベント
            OnClosed();
            //イベントの削除
            if(eventSubscriber is not null)
            {
                dispacher.Unsubscribe(eventSubscriber);
            }
            if(current is not null)
            {
                current.Closed -= Page_Closed;
            }
            //元ページを開く
            if (parent is not null)
            {
                parent.Visibility = Visibility.Visible;
            }
        }
    }
}
