using Cysharp.Threading.Tasks;
using System;

namespace OsirisGames.WindowsSystem
{
    public interface IWindowController<in TType>
    {
        UniTask<T> Push<T>(TType windowType) where T : IWindow;
        UniTask Pop();
        UniTask Pop(TType windowType);
        UniTask PopAll();
        UniTask PopUntil(int index);
        UniTask PopUntil(TType windowType);
    }
}
