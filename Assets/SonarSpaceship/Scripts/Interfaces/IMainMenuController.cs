using UnityTranslator.Objects;

namespace SonarSpaceship
{
    public interface IMainMenuController : IBehaviour
    {
        StringTranslationObjectScript ExitGameTitleStringTranslation { get; set; }

        StringTranslationObjectScript ExitGameMessageStringTranslation { get; set; }

        EMainMenuState MainMenuState { get; set; }

        event TapToContinueShownDelegate OnTapToContinueShown;

        event TapToContinueHiddenDelegate OnTapToContinueHidden;

        event MainMenuShownDelegate OnMainMenuShown;

        event MainMenuHiddenDelegate OnMainMenuHidden;

        event ProfileMenuShownDelegate OnProfileMenuShown;

        event ProfileMenuHiddenDelegate OnProfileMenuHidden;

        event SettingsMenuShownDelegate OnSettingsMenuShown;

        event SettingsMenuHiddenDelegate OnSettingsMenuHidden;

        event CreditsMenuShownDelegate OnCreditsMenuShown;

        event CreditsMenuHiddenDelegate OnCreditsMenuHidden;

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
