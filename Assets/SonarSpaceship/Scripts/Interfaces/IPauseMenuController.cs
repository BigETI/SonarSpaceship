using UnityTranslator.Objects;

namespace SonarSpaceship
{
    public interface IPauseMenuController : IBehaviour
    {
        StringTranslationObjectScript ExitGameTitleStringTranslation { get; set; }

        StringTranslationObjectScript ExitGameMessageStringTranslation { get; set; }

        EPauseMenuState PauseMenuState { get; set; }

        event GamePausedDelegate OnGamePaused;

        event GameResumedDelegate OnGameResumed;

        event PauseMenuShownDelegate OnPauseMenuShown;

        event SettingsMenuShownDelegate OnSettingsMenuShown;

        void ResumeGame();

        void ShowPauseMenu();

        void ShowSettingsMunu();

        void RequestShowLevelSelection();
    }
}
