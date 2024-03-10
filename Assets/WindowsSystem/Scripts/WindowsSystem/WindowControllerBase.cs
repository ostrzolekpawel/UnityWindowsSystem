using Cysharp.Threading.Tasks;

namespace OsirisGames.WindowsSystem
{
    public abstract class WindowControllerBase<TWindowType> : IWindowController<TWindowType>
    {
        protected readonly IWindowProvider<TWindowType> _windowProvider;
        protected readonly IWindowStack _windowStack;

        public WindowControllerBase(IWindowProvider<TWindowType> windowProvider, IWindowStack windowStack)
        {
            _windowProvider = windowProvider;
            _windowStack = windowStack;
        }

        public async UniTask<T> Push<T>(TWindowType windowType) where T : IWindow
        {
            T window = await _windowProvider.GetWindow<T>(windowType);

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

        public UniTask Pop(TWindowType windowType)
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

        public UniTask PopUntil(TWindowType windowType)
        {
            throw new System.NotImplementedException();
        }
    }
}
