namespace SonarSpaceship
{
    public interface IMainMenuController : IBehaviour
    {
        EMainMenuState MainMenuState { get; set; }

        event TapToContinueShownDelegate OnTapToContinueShown;

        event MainMenuShownDelegate OnMainMenuShown;

        event ProfileMenuShownDelegate OnProfileMenuShown;

        event SettingsMenuShownDelegate OnSettingsMenuShown;

        void ShowMainMenu();

        void ShowProfileMenu();

        void ShowSettingsMenu();

        void ShowLevelSelectionMenu();

        void ShowCreditsMenu();

        void Exit();
    }
}
