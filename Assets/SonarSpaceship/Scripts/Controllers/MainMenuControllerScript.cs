using System;
using UnityDialog;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnitySceneLoaderManager;
using UnityTranslator.Objects;

namespace SonarSpaceship.Controllers
{
    public class MainMenuControllerScript : MonoBehaviour, IMainMenuController
    {
        [SerializeField]
        private StringTranslationObjectScript exitGameTitleStringTranslation = default;

        [SerializeField]
        private StringTranslationObjectScript exitGameMessageStringTranslation = default;

        [SerializeField]
        private UnityEvent onTapToContinueShown = default;

        [SerializeField]
        private UnityEvent onTapToContinueHidden = default;

        [SerializeField]
        private UnityEvent onMainMenuShown = default;

        [SerializeField]
        private UnityEvent onMainMenuHidden = default;

        [SerializeField]
        private UnityEvent onProfileMenuShown = default;

        [SerializeField]
        private UnityEvent onProfileMenuHidden = default;

        [SerializeField]
        private UnityEvent onSettingsMenuShown = default;

        [SerializeField]
        private UnityEvent onSettingsMenuHidden = default;

        [SerializeField]
        private UnityEvent onCreditsMenuShown = default;

        [SerializeField]
        private UnityEvent onCreditsMenuHidden = default;

        [SerializeField]
        private UnityEvent onExitGameRequestAccepted = default;

        [SerializeField]
        private UnityEvent onExitGameRequestDenied = default;

        private EMainMenuState mainMenuState = EMainMenuState.Nothing;

        public StringTranslationObjectScript ExitGameTitleStringTranslation
        {
            get => exitGameTitleStringTranslation;
            set => exitGameTitleStringTranslation = value;
        }

        public StringTranslationObjectScript ExitGameMessageStringTranslation
        {
            get => exitGameMessageStringTranslation;
            set => exitGameMessageStringTranslation = value;
        }

        public static bool IsShowingInitialMainMenuState { get; private set; } = true;

        public EMainMenuState MainMenuState
        {
            get => mainMenuState;
            set
            {
                if ((mainMenuState != value) && (value != EMainMenuState.Nothing))
                {
                    EMainMenuState old_main_menu_state = mainMenuState;
                    mainMenuState = value;
                    switch (old_main_menu_state)
                    {
                        case EMainMenuState.TapToContinue:
                            if (onTapToContinueHidden != null)
                            {
                                onTapToContinueHidden.Invoke();
                            }
                            OnTapToContinueHidden?.Invoke();
                            break;
                        case EMainMenuState.MainMenu:
                            if (onMainMenuHidden != null)
                            {
                                onMainMenuHidden.Invoke();
                            }
                            OnMainMenuHidden?.Invoke();
                            break;
                        case EMainMenuState.ProfileMenu:
                            if (onProfileMenuHidden != null)
                            {
                                onProfileMenuHidden.Invoke();
                            }
                            OnProfileMenuHidden?.Invoke();
                            break;
                        case EMainMenuState.SettingsMenu:
                            if (onSettingsMenuHidden != null)
                            {
                                onSettingsMenuHidden.Invoke();
                            }
                            OnSettingsMenuHidden?.Invoke();
                            break;
                        case EMainMenuState.CreditsMenu:
                            if (onCreditsMenuHidden != null)
                            {
                                onCreditsMenuHidden.Invoke();
                            }
                            OnCreditsMenuHidden?.Invoke();
                            break;
                    }
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
                        case EMainMenuState.CreditsMenu:
                            if (onCreditsMenuShown != null)
                            {
                                onCreditsMenuShown.Invoke();
                            }
                            OnCreditsMenuShown?.Invoke();
                            break;
                    }
                }
            }
        }

        public event TapToContinueShownDelegate OnTapToContinueShown;

        public event TapToContinueHiddenDelegate OnTapToContinueHidden;

        public event MainMenuShownDelegate OnMainMenuShown;

        public event MainMenuHiddenDelegate OnMainMenuHidden;

        public event ProfileMenuShownDelegate OnProfileMenuShown;

        public event ProfileMenuHiddenDelegate OnProfileMenuHidden;

        public event SettingsMenuShownDelegate OnSettingsMenuShown;

        public event SettingsMenuHiddenDelegate OnSettingsMenuHidden;

        public event CreditsMenuShownDelegate OnCreditsMenuShown;

        public event CreditsMenuHiddenDelegate OnCreditsMenuHidden;

        public event ExitGameRequestAcceptedDelegate OnExitGameRequestAccepted;

        public event ExitGameRequestDeniedDelegate OnExitGameRequestDenied;

        public void ShowMainMenu() => MainMenuState = EMainMenuState.MainMenu;

        public void ShowProfileMenu() => MainMenuState = EMainMenuState.ProfileMenu;

        public void ShowSettingsMenu() => MainMenuState = EMainMenuState.SettingsMenu;

        public void ShowCreditsMenu() => MainMenuState = EMainMenuState.CreditsMenu;

        public void ShowLevelSelectionMenu() => SceneLoaderManager.LoadScenes("LevelSelectionMenuScene");

        public void OpenURL(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }
            Application.OpenURL(url);
        }

        public void RequestExitingGame()
        {
            Dialogs.Show
            (
                exitGameTitleStringTranslation ? exitGameTitleStringTranslation.ToString() : string.Empty,
                exitGameMessageStringTranslation ? exitGameMessageStringTranslation.ToString() : string.Empty,
                EDialogType.Information,
                EDialogButtons.YesNo,
                (response, _) =>
                {
                    if (response == EDialogResponse.Yes)
                    {
                        if (onExitGameRequestAccepted != null)
                        {
                            onExitGameRequestAccepted.Invoke();
                        }
                        OnExitGameRequestAccepted?.Invoke();
                    }
                    else
                    {
                        if (onExitGameRequestDenied != null)
                        {
                            onExitGameRequestDenied.Invoke();
                        }
                        OnExitGameRequestDenied?.Invoke();
                    }
                }
            );
        }

        public void ExitGame()
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
