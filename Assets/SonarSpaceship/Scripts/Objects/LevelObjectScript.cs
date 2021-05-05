using UnityEngine;
using UnityTranslator.Objects;

namespace SonarSpaceship
{
    [CreateAssetMenu(fileName = "Level", menuName = "Sonar Spaceship/Level")]
    public class LevelObjectScript : ScriptableObject, ILevelObject
    {
        [SerializeField]
        private StringTranslationObjectScript levelNameStringTranslation = default;

        [SerializeField]
        private string scenePath = string.Empty;

        public StringTranslationObjectScript LevelNameStringTranslation => levelNameStringTranslation;

        public string ScenePath => scenePath ?? string.Empty;

        public string LevelName => levelNameStringTranslation ? levelNameStringTranslation.ToString() : name;
    }
}
