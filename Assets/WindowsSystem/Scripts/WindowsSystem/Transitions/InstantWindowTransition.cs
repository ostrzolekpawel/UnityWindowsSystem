using Cysharp.Threading.Tasks;

namespace OsirisGames.WindowsSystem
{
    public class InstantWindowTransition : IWindowTransition
    {
        public UniTask Enter()
        {
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}
