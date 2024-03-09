using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace OsirisGames.WindowsSystem
{
    public class WindowStack : IWindowStack
    {
        private readonly Stack<Window> _windows;

        public async UniTask Push(Window nextWindow)
        {
            _windows.Push(nextWindow);
            await nextWindow.Open();
        }

        public async UniTask Pop(Func<Window, UniTask> onPop = null)
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

        public async UniTask PopAll(Func<Window, UniTask> onPop = null)
        {
            while (_windows.Count > 0)
            {
                await Pop(onPop);
            }
        }
    }
}
