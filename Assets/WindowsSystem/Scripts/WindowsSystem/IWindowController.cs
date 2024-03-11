using Cysharp.Threading.Tasks;
using System;

namespace OsirisGames.WindowsSystem
{
    public interface IWindowController<in TType, TWindow> where TWindow : IWindow
    {
        UniTask<TWindow> Push(TType windowType);
        UniTask Pop();
        UniTask Pop(TType windowType);
        UniTask PopAll();
        UniTask PopUntil(int index);
        UniTask PopUntil(TType windowType);
    }
}
