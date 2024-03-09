using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OsirisGames.WindowsSystem
{
    // example implementations
    public class WindowProviderGetFromScene : MonoBehaviour, IWindowProvider<WindowType>
    {
        [SerializeField] private WindowSceneConfig _windows;

        public UniTask<T> GetWindow<T>(WindowType windowType) where T : IWindow
        {
            var window = _windows.GetWindow(windowType);
            if (window != null)
            {
                return UniTask.FromResult((T)window);
            }

            return UniTask.FromResult<T>(default);
        }

        public UniTask ReleaseWindow(IWindow window)
        {
            return UniTask.CompletedTask;
        }
    }
}
