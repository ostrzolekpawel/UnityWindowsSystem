using Cysharp.Threading.Tasks;
using System;

namespace OsirisGames.WindowsSystem
{
    public interface IWindowStack
    {
        UniTask Push(IWindow window);
        UniTask Pop(Func<IWindow, UniTask> onPop = null);
        UniTask PopAll(Func<IWindow, UniTask> onPop = null);
    }
}
