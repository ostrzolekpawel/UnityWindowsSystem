using Cysharp.Threading.Tasks;

namespace OsirisGames.WindowsSystem
{
    public interface IWindowTransition
    {
        UniTask Enter();
        UniTask Exit();
    }
}
