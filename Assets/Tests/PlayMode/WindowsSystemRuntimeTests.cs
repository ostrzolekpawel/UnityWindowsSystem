using Cysharp.Threading.Tasks;
using Moq;
using NUnit.Framework;
using OsirisGames.WindowsSystem;
using System.Collections;
using UnityEngine.TestTools;

public class WindowsSystemRuntimeTests
{
    [UnityTest]
    public IEnumerator PushWindow_ReturnUniTask() => UniTask.ToCoroutine(async () =>
    {
        // Arrange
        var windowProviderMock = new Mock<IWindowProvider<int, IWindow>>();
        var windowStackMock = new Mock<IWindowStack>();
        var windowController = new Mock<WindowControllerBase<int, IWindow>>(windowProviderMock.Object, windowStackMock.Object);
        var windowType = 1;
        var window = new Mock<IWindow>();
        windowStackMock.Setup(x => x.Push(window.Object)).Returns(UniTask.CompletedTask);
        windowProviderMock.Setup(x => x.GetWindow(windowType)).Returns(UniTask.FromResult(window.Object));
        // Act
        var result = await windowController.Object.Push(windowType);

        // Assert
        Assert.AreEqual(window.Object, result);
        windowStackMock.Verify(x => x.Push(window.Object), Times.Once);
    });
}
