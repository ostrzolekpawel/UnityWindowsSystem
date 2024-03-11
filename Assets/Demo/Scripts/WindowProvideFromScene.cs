using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OsirisGames.WindowsSystem
{
    public class WindowProvideFromScene : MonoBehaviour, IWindowProvider<WindowType, Window>
    {
        [SerializeField] private WindowSceneConfig _windows;

        public UniTask<Window> GetWindow(WindowType windowType)
        {
            var window = _windows.GetWindow(windowType);
            if (window != null && window is Window typedWindow)
            {
                window.gameObject.SetActive(true);
                return UniTask.FromResult(typedWindow);
            }

            return UniTask.FromResult<Window>(default);
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
