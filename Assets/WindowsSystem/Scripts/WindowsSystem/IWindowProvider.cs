using Cysharp.Threading.Tasks;

namespace OsirisGames.WindowsSystem
{
    public interface IWindowProvider<TType>
    {
        UniTask<T> GetWindow<T>(TType windowType) where T : IWindow;
        UniTask ReleaseWindow(IWindow window);
    }
}
