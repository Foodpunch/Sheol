using System;
using Cysharp.Threading.Tasks;

namespace ProjectRuntime.UI.PanelSystem
{
    public interface IPanel
    {
        Func<UniTask> OnTransitionIn { get; }
        Func<UniTask> OnTransitionOut { get; }
    }
}
