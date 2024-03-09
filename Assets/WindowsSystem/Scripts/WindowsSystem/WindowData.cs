using System;
using UnityEngine;

namespace OsirisGames.WindowsSystem
{
    [Serializable]
    public class WindowData
    {
        [SerializeField] private WindowType _windowType;
        [SerializeField] private Window _window;

        public WindowType WindowType => _windowType;
        public Window Window => _window;
    }
}
