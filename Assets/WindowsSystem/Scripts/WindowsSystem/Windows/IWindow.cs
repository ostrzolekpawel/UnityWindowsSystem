using Cysharp.Threading.Tasks;
using System;

namespace OsirisGames.WindowsSystem
{
    public interface IWindow
    {
        Action OnEnterStart { get; set; }
        Action OnEnterEnd { get; set; }
        Action OnExitStart { get; set; }
        Action OnExitEnd { get; set; }

        WindowState CurrentState { get; }

        IWindowTransition WindowTransition { get; }

        UniTask Setup();

        UniTask Open();

        UniTask Close();
    }
}
