using UnityDialog;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnitySceneLoaderManager;
using UnityTranslator.Objects;

namespace SonarSpaceship.Controllers
{
    public class PauseMenuControllerScript : MonoBehaviour, IPauseMenuController
    {
        [SerializeField]
        private StringTranslationObjectScript exitGameTitleStringTranslation = default;

        [SerializeField]
        private StringTranslationObjectScript exitGameMessageStringTranslation = default;

        [SerializeField]
        private UnityEvent onGamePaused = default;

        [SerializeField]
        private UnityEvent onGameResumed = default;

        [SerializeField]
        private UnityEvent onPauseMenuShown = default;

        [SerializeField]
        private UnityEvent onSettingsMenuShown = default;

        private EPauseMenuState pauseMenuState;

        private bool isEscapeKeyDown;

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

        public EPauseMenuState PauseMenuState
        {
            get => pauseMenuState;
            set
            {
                if (pauseMenuState != value)
                {
                    EPauseMenuState old_pause_menu_state = pauseMenuState;
                    pauseMenuState = value;
                    switch (pauseMenuState)
                    {
                        case EPauseMenuState.None:
                            Time.timeScale = 1.0f;
                            if (onGameResumed != null)
                            {
                                onGameResumed.Invoke();
                            }
                            OnGameResumed?.Invoke();
                            break;
                        case EPauseMenuState.PauseMenu:
                            Time.timeScale = 0.0f;
                            if (old_pause_menu_state == EPauseMenuState.None)
                            {
                                if (onGamePaused != null)
                                {
                                    onGamePaused.Invoke();
                                }
                                OnGamePaused?.Invoke();
                            }
                            if (onPauseMenuShown != null)
                            {
                                onPauseMenuShown.Invoke();
                            }
                            OnPauseMenuShown?.Invoke();
                            break;
                        case EPauseMenuState.SettingsMenu:
                            Time.timeScale = 0.0f;
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

        public event GamePausedDelegate OnGamePaused;

        public event GameResumedDelegate OnGameResumed;

        public event PauseMenuShownDelegate OnPauseMenuShown;

        public event SettingsMenuShownDelegate OnSettingsMenuShown;

        public void ResumeGame() => PauseMenuState = EPauseMenuState.None;

        public void ShowPauseMenu() => PauseMenuState = EPauseMenuState.PauseMenu;

        public void ShowSettingsMunu() => PauseMenuState = EPauseMenuState.SettingsMenu;

        public void RequestShowLevelSelection()
        {
            Dialogs.Show
            (
                exitGameTitleStringTranslation ? exitGameTitleStringTranslation.ToString() : string.Empty,
                exitGameMessageStringTranslation ? exitGameMessageStringTranslation.ToString() : string.Empty,
                EDialogType.Warning,
                EDialogButtons.YesNo,
                (response, _) =>
                {
                    if (response == EDialogResponse.Yes)
                    {
                        Time.timeScale = 1.0f;
                        SceneLoaderManager.LoadScenes("LevelSelectionMenuScene");
                    }
                }
            );
        }

        private void Update()
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard != null)
            {
                bool is_escape_key_pressed = keyboard.escapeKey.IsPressed();
                if (isEscapeKeyDown != is_escape_key_pressed)
                {
                    isEscapeKeyDown = is_escape_key_pressed;
                    if (!isEscapeKeyDown)
                    {
                        switch (pauseMenuState)
                        {
                            case EPauseMenuState.None:
                            case EPauseMenuState.SettingsMenu:
                                PauseMenuState = EPauseMenuState.PauseMenu;
                                break;
                            case EPauseMenuState.PauseMenu:
                                PauseMenuState = EPauseMenuState.None;
                                break;
                        }
                    }
                }
            }
        }
    }
}
