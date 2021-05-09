using SonarSpaceship.Objects;
using TMPro;
using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public class LevelSelectionUIControllerScript : MonoBehaviour, ILevelSelectionUIController
    {
        [SerializeField]
        private TextMeshProUGUI levelNameText = default;

        [SerializeField]
        private LevelObjectScript level = default;

        public TextMeshProUGUI LevelNameText
        {
            get => levelNameText;
            set => levelNameText = value;
        }

        public LevelObjectScript Level
        {
            get => level;
            set => level = value;
        }

        public void PlayLevel()
        {
            if (level)
            {
                GameManager.LoadLevel(level);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (levelNameText)
            {
                levelNameText.text = level ? level.LevelName : "N/A";
            }
        }
#endif

        private void Start()
        {
            if (levelNameText)
            {
                levelNameText.text = level ? level.LevelName : "N/A";
            }
            else
            {
                Debug.LogError("Please assign a level name text component to this game object.", this);
            }
            if (level)
            {
                if (GameManager.SelectedProfile is IProfile profile)
                {
                    foreach (LevelObjectScript required_level in level.RequiredLevels)
                    {
                        if (required_level)
                        {
                            if (!profile.IsLevelFinished(required_level))
                            {
                                Destroy(gameObject);
                                break;
                            }
                        }
                        else
                        {
                            Debug.LogError($"A required level entry in \"{ level.name }\" is null.");
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Please assign a level to this game object.", this);
            }
        }
    }
}
