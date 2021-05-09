using UnityEngine;
using UnitySceneLoaderManager;

namespace SonarSpaceship.Controllers
{
    public class IntroControllerScript : MonoBehaviour, IIntroController
    {
        public void ShowMainMenu() => SceneLoaderManager.LoadScenes("MainMenuScene");
    }
}
