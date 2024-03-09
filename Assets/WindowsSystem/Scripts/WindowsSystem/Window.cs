using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace OsirisGames.WindowsSystem
{
    public enum State
    {
        None,
        EnterStart,
        EnterEnd,
        ExitStart,
        ExitEnd
    }

    public interface IWindow
    {
        Action OnEnterStart { get; set; }
        Action OnEnterEnd { get; set; }
        Action OnExitStart { get; set; }
        Action OnExitEnd { get; set; }

        State CurrentState { get; }

        IWindowTransition WindowTransition { get; }

        UniTask Setup();

        UniTask Open();

        UniTask Close();
    }
    public abstract class Window : MonoBehaviour, IWindow
    {
        public Action OnEnterStart { get; set; }
        public Action OnEnterEnd { get; set; }
        public Action OnExitStart { get; set; }
        public Action OnExitEnd { get; set; }

        public State CurrentState { get; private set; } = State.None;

        private IWindowTransition _windowTransition;
        public IWindowTransition WindowTransition => _windowTransition ??= GetTransition(new InstantWindowTransition());

        public abstract UniTask Setup();

        public virtual async UniTask Open()
        {
            if (CurrentState == State.EnterStart || CurrentState == State.EnterEnd)
            {
                return;
            }

            CurrentState = State.EnterStart;
            OnEnterStart?.Invoke();
            await WindowTransition.Enter();

            CurrentState = State.EnterEnd;
            OnEnterEnd?.Invoke();
            await Setup();
        }

        public virtual async UniTask Close()
        {
            if (CurrentState == State.ExitStart || CurrentState == State.ExitEnd)
            {
                return;
            }

            CurrentState = State.ExitStart;
            OnExitStart?.Invoke();
            await WindowTransition.Exit();

            CurrentState = State.ExitEnd;
            OnExitEnd?.Invoke();
        }

        protected IWindowTransition GetTransition(IWindowTransition defaultTransition)
        {
            IWindowTransition transition = GetComponentInChildren<IWindowTransition>();
            return transition ?? defaultTransition;
        }
    }
}
