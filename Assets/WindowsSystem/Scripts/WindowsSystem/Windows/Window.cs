using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace OsirisGames.WindowsSystem
{
    public abstract class Window : MonoBehaviour, IWindow
    {
        public Action OnEnterStart { get; set; }
        public Action OnEnterEnd { get; set; }
        public Action OnExitStart { get; set; }
        public Action OnExitEnd { get; set; }

        public WindowState CurrentState { get; private set; } = WindowState.None;

        private IWindowTransition _windowTransition;
        public IWindowTransition WindowTransition => _windowTransition ??= GetTransition(new InstantWindowTransition());

        public abstract UniTask Setup();

        public virtual async UniTask Open()
        {
            if (CurrentState == WindowState.EnterStart || CurrentState == WindowState.EnterEnd)
            {
                return;
            }

            CurrentState = WindowState.EnterStart;
            OnEnterStart?.Invoke();
            await WindowTransition.Enter();

            CurrentState = WindowState.EnterEnd;
            OnEnterEnd?.Invoke();
            await Setup();
        }

        public virtual async UniTask Close()
        {
            if (CurrentState == WindowState.ExitStart || CurrentState == WindowState.ExitEnd)
            {
                return;
            }

            CurrentState = WindowState.ExitStart;
            OnExitStart?.Invoke();
            await WindowTransition.Exit();

            CurrentState = WindowState.ExitEnd;
            OnExitEnd?.Invoke();
        }

        protected IWindowTransition GetTransition(IWindowTransition defaultTransition)
        {
            IWindowTransition transition = GetComponentInChildren<IWindowTransition>();
            return transition ?? defaultTransition;
        }
    }
}
