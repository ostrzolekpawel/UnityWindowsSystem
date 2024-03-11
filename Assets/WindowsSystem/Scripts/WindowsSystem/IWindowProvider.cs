using Cysharp.Threading.Tasks;

namespace OsirisGames.WindowsSystem
{
    public interface IWindowProvider<TType, TWindow> where TWindow : IWindow
    {
        UniTask<TWindow> GetWindow(TType windowType);
        UniTask ReleaseWindow(IWindow window);
    }
}
