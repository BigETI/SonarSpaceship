using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnitySceneLoaderManager;

namespace SonarSpaceship.Controllers
{
    public class MainMenuControllerScript : MonoBehaviour, IMainMenuController
    {
        [SerializeField]
        private UnityEvent onTapToContinueShown = default;

        [SerializeField]
        private UnityEvent onMainMenuShown = default;

        [SerializeField]
        private UnityEvent onProfileMenuShown = default;

        [SerializeField]
        private UnityEvent onSettingsMenuShown = default;

        private EMainMenuState mainMenuState = EMainMenuState.Nothing;

        public static bool IsShowingInitialMainMenuState { get; private set; } = true;

        public EMainMenuState MainMenuState
        {
            get => mainMenuState;
            set
            {
                if ((mainMenuState != value) && (value != EMainMenuState.Nothing))
                {
                    mainMenuState = value;
                    switch (mainMenuState)
                    {
                        case EMainMenuState.TapToContinue:
                            if (onTapToContinueShown != null)
                            {
                                onTapToContinueShown.Invoke();
                            }
                            OnTapToContinueShown?.Invoke();
                            break;
                        case EMainMenuState.MainMenu:
                            if (onMainMenuShown != null)
                            {
                                onMainMenuShown.Invoke();
                            }
                            OnMainMenuShown?.Invoke();
                            break;
                        case EMainMenuState.ProfileMenu:
                            if (onProfileMenuShown != null)
                            {
                                onProfileMenuShown.Invoke();
                            }
                            OnProfileMenuShown?.Invoke();
                            break;
                        case EMainMenuState.SettingsMenu:
                            if (onSettingsMenuShown != null)
                            {
                                onSettingsMenuShown.Invoke();
                            }
                            OnSettingsMenuShown?.Invoke();
                            break;
                    }
                }
            }
        }

        public event TapToContinueShownDelegate OnTapToContinueShown;

        public event MainMenuShownDelegate OnMainMenuShown;

        public event ProfileMenuShownDelegate OnProfileMenuShown;

        public event SettingsMenuShownDelegate OnSettingsMenuShown;

        public void ShowMainMenu() => MainMenuState = EMainMenuState.MainMenu;

        public void ShowProfileMenu() => MainMenuState = EMainMenuState.ProfileMenu;

        public void ShowSettingsMenu() => MainMenuState = EMainMenuState.SettingsMenu;

        public void ShowLevelSelectionMenu() => SceneLoaderManager.LoadScenes("LevelSelectionMenuScene");

        public void ShowCreditsMenu() => SceneLoaderManager.LoadScenes("CreditsMenuScene");

        public void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void Start()
        {
            if (IsShowingInitialMainMenuState)
            {
                MainMenuState = EMainMenuState.TapToContinue;
                IsShowingInitialMainMenuState = false;
            }
            else
            {
                MainMenuState = EMainMenuState.MainMenu;
            }
        }

        private void Update()
        {
            if (mainMenuState == EMainMenuState.TapToContinue)
            {
                Mouse mouse = Mouse.current;
                Touchscreen touchscreen = Touchscreen.current;
                if (mouse != null)
                {
                    if
                    (
                        mouse.leftButton.IsPressed() ||
                        mouse.middleButton.IsPressed() ||
                        mouse.rightButton.IsPressed() ||
                        mouse.forwardButton.IsPressed() ||
                        mouse.backButton.IsPressed()
                    )
                    {
                        MainMenuState = EMainMenuState.MainMenu;
                    }
                }
                if (touchscreen != null)
                {
                    if (touchscreen.press.IsPressed())
                    {
                        MainMenuState = EMainMenuState.MainMenu;
                    }
                }
            }
        }
    }
}
