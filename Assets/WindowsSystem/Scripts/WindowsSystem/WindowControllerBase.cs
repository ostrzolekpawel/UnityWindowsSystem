using Cysharp.Threading.Tasks;

namespace OsirisGames.WindowsSystem
{
    public abstract class WindowControllerBase<TType, TWindow> : IWindowController<TType, TWindow> where TWindow : IWindow
    {
        protected readonly IWindowProvider<TType, TWindow> _windowProvider;
        protected readonly IWindowStack _windowStack;
        
        public WindowControllerBase(IWindowProvider<TType, TWindow> windowProvider, IWindowStack windowStack)
        {
            _windowProvider = windowProvider;
            _windowStack = windowStack;
        }

        public async UniTask<TWindow> Push(TType windowType)
        {
            TWindow window = await _windowProvider.GetWindow(windowType);

            if (window != null)
            {
                await _windowStack.Push(window);
            }

            return window;
        }

        public async UniTask Pop()
        {
            await _windowStack.Pop(ReleaseOnPop);
        }

        private async UniTask ReleaseOnPop(IWindow poped)
        {
            await _windowProvider.ReleaseWindow(poped);
        }

        public UniTask Pop(TType windowType)
        {
            throw new System.NotImplementedException();
        }

        public async UniTask PopAll()
        {
            await _windowStack.PopAll(ReleaseOnPop);
        }

        public UniTask PopUntil(int index)
        {
            throw new System.NotImplementedException();
        }

        public UniTask PopUntil(TType windowType)
        {
            throw new System.NotImplementedException();
        }
    }
}
