using UnityEngine.UI;

namespace SonarSpaceship
{
    public interface IGameButtonUIController : IBehaviour
    {
        Button GameButton { get; }
    }
}
