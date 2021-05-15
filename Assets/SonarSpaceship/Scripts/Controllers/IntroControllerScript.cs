using UnityEngine;
using UnityEngine.InputSystem;
using UnitySceneLoaderManager;

namespace SonarSpaceship.Controllers
{
    public class IntroControllerScript : MonoBehaviour, IIntroController
    {
        public void ShowMainMenu() => SceneLoaderManager.LoadScenes("MainMenuScene");

        private void Update()
        {
            Keyboard keyboard = Keyboard.current;
            Mouse mouse = Mouse.current;
            Touchscreen touchscreen = Touchscreen.current;
            if (keyboard != null)
            {
                if (keyboard.anyKey.isPressed)
                {
                    ShowMainMenu();
                }
            }
            if (mouse != null)
            {
                if
                (
                    mouse.leftButton.isPressed ||
                    mouse.rightButton.isPressed ||
                    mouse.middleButton.isPressed ||
                    mouse.forwardButton.isPressed ||
                    mouse.backButton.isPressed
                )
                {
                    ShowMainMenu();
                }
            }
            if (touchscreen != null)
            {
                if (touchscreen.press.isPressed)
                {
                    ShowMainMenu();
                }
            }
        }
    }
}
