using Cysharp.Threading.Tasks;
using System;

namespace OsirisGames.WindowsSystem
{
    public interface IWindowStack
    {
        UniTask Push(Window window);
        UniTask Pop(Func<Window, UniTask> onPop = null);
        UniTask PopAll(Func<Window, UniTask> onPop = null);
    }
}
