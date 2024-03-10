using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OsirisGames.WindowsSystem
{
    public class WindowProvideFromScene : MonoBehaviour, IWindowProvider<WindowType>
    {
        [SerializeField] private WindowSceneConfig _windows;

        public UniTask<T> GetWindow<T>(WindowType windowType) where T : IWindow
        {
            var window = _windows.GetWindow(windowType);
            if (window != null && window is T typedWindow)
            {
                window.gameObject.SetActive(true);
                return UniTask.FromResult(typedWindow);
            }

            return UniTask.FromResult<T>(default);
        }

        public UniTask ReleaseWindow(IWindow window)
        {
            if (window != null && window is Window monoWindow)
            {
                monoWindow.gameObject.SetActive(false);
                // other wise throw exception
            }
            return UniTask.CompletedTask;
        }
    }
}
