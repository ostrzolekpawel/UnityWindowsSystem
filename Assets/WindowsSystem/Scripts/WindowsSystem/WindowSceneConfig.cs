using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OsirisGames.WindowsSystem
{
    [Serializable]
    public class WindowSceneConfig
    {
        [SerializeField] private List<WindowData> _windows;

        public IWindow GetWindow(WindowType type)
        {
            return _windows.FirstOrDefault(x => x.WindowType == type)?.Window;
        }
    }
}
