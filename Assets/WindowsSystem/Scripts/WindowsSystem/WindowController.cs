using Cysharp.Threading.Tasks;

namespace OsirisGames.WindowsSystem
{
    public class WindowController : IWindowController<WindowType>
    {
        private readonly IWindowProvider<WindowType> _windowProvider;
        private readonly IWindowStack _windowStack;

        public WindowController(IWindowProvider<WindowType> windowProvider, IWindowStack windowStack)
        {
            _windowProvider = windowProvider;
            _windowStack = windowStack;
        }

        public async UniTask<T> Push<T>(WindowType windowType) where T : Window
        {
            T window = await _windowProvider.GetWindow<T>(windowType);

            if (window)
            {
                await _windowStack.Push(window);
            }

            return window;
        }

        public async UniTask Pop()
        {
            await _windowStack.Pop(ReleaseOnPop);
        }

        private async UniTask ReleaseOnPop(Window poped)
        {
            await _windowProvider.ReleaseWindow(poped);
        }

        public UniTask Pop(WindowType windowType)
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

        public UniTask PopUntil(WindowType windowType)
        {
            throw new System.NotImplementedException();
        }
    }
}
