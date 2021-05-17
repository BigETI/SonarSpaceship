using UnityTranslator.Objects;

namespace SonarSpaceship
{
    public interface IMainMenuController : IBehaviour
    {
        StringTranslationObjectScript ExitGameTitleStringTranslation { get; set; }

        StringTranslationObjectScript ExitGameMessageStringTranslation { get; set; }

        EMainMenuState MainMenuState { get; set; }

        event TapToContinueShownDelegate OnTapToContinueShown;

        event MainMenuShownDelegate OnMainMenuShown;

        event ProfileMenuShownDelegate OnProfileMenuShown;

        event SettingsMenuShownDelegate OnSettingsMenuShown;

        event ExitGameRequestAcceptedDelegate OnExitGameRequestAccepted;

        event ExitGameRequestDeniedDelegate OnExitGameRequestDenied;

        void ShowMainMenu();

        void ShowProfileMenu();

        void ShowSettingsMenu();

        void ShowCreditsMenu();

        void ShowLevelSelectionMenu();

        void OpenURL(string url);

        void RequestExitingGame();

        void ExitGame();
    }
}
