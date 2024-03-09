using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OsirisGames.WindowsSystem
{
    public class WindowProvideFromScene : MonoBehaviour, IWindowProvider<WindowType>
    {
        [SerializeField] private WindowSceneConfig _windows;

        public UniTask<T> GetWindow<T>(WindowType windowType) where T : Window
        {
            var window = _windows.GetWindow(windowType);
            if (window)
            {
                window.gameObject.SetActive(true);
                return UniTask.FromResult(window as T);
            }

            return UniTask.FromResult<T>(null);
        }

        public UniTask ReleaseWindow(Window window)
        {
            window.gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }
    }
}
