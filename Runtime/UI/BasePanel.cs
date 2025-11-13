using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace ProjectRuntime.UI.PanelSystem
{
    public abstract class BasePanel : Form, IPanel
    {
        public delegate void Handler(BasePanel dlg);

        public event Handler EvtCloseOrdered;

        public bool Closing { get; private set; }
        public bool ShowAndTransitionInComplete { get; set; }
        public bool IsShowingTransitionAnimation { get; set; }
        public virtual Func<UniTask> OnTransitionIn { get; }
        public virtual Func<UniTask> OnTransitionOut { get; }

        public virtual void PlayStart()
        {

        }

        public virtual async UniTask InitGenericAsync(IEnumerable<string> args = null)
        {
            await UniTask.CompletedTask;
        }

        public virtual async UniTask InitTutorialAsync(IEnumerable<object> tutorialObjects)
        {
            await UniTask.CompletedTask;
        }

        public virtual void Close()
        {
            this.Close(false);
        }

        public virtual bool Close(bool force)
        {
            this.Closing = true;
            this.EvtCloseOrdered?.Invoke(this);
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.Close();
        }

        public virtual void OnTransitInCompleted()
        {
        }
    }
}

