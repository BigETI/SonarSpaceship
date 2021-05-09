using UnityEngine;
using UnitySceneLoaderManager;

namespace SonarSpaceship.Controllers
{
    public class LevelSelectionMenuControllerScript : MonoBehaviour, ILevelSelectionMenuController
    {
        public void ShowMainMenu() => SceneLoaderManager.LoadScenes("MainMenuScene");
    }
}
