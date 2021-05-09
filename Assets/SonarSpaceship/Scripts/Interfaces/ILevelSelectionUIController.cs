using SonarSpaceship.Objects;
using TMPro;

namespace SonarSpaceship
{
    public interface ILevelSelectionUIController : IBehaviour
    {
        TextMeshProUGUI LevelNameText { get; set; }

        LevelObjectScript Level { get; set; }

        void PlayLevel();
    }
}
