using Cysharp.Threading.Tasks;
using ProjectRuntime.UI.PanelSystem;

namespace ProjectRuntime.UI
{
    public static class BasePanelExtensions
    {
        public static async UniTask WaitWhilePanelIsAlive(this BasePanel panel)
        {
            while (panel)
            {
                await UniTask.Yield();
            }
        }
    }
}