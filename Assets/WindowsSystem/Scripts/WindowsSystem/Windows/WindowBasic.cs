using Cysharp.Threading.Tasks;

namespace OsirisGames.WindowsSystem
{
    public class WindowBasic : Window
    {
        public override UniTask Setup()
        {
            return UniTask.CompletedTask;
        }

        public override async UniTask Open()
        {
            gameObject.SetActive(true);
            await base.Open();
        }
    }
}
