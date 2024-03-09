using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace OsirisGames.WindowsSystem
{
    public class WindowStack : IWindowStack
    {
        private readonly Stack<IWindow> _windows;

        public async UniTask Push(IWindow nextWindow)
        {
            _windows.Push(nextWindow);
            await nextWindow.Open();
        }

        public async UniTask Pop(Func<IWindow, UniTask> onPop = null)
        {
            var window = _windows.Pop();
            if (window != null)
            {
                await window.Close();

                if (onPop != null)
                {
                    await onPop.Invoke(window);
                }
            }
        }

        public async UniTask PopAll(Func<IWindow, UniTask> onPop = null)
        {
            while (_windows.Count > 0)
            {
                await Pop(onPop);
            }
        }
    }
}
