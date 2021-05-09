using System;
using System.Collections.Generic;
using UnityEngine;
using UnityTranslator.Objects;

namespace SonarSpaceship.Objects
{
    [CreateAssetMenu(fileName = "Level", menuName = "Sonar Spaceship/Level")]
    public class LevelObjectScript : ScriptableObject, ILevelObject
    {
        [SerializeField]
        private StringTranslationObjectScript levelNameStringTranslation = default;

        [SerializeField]
        private string scenePath = string.Empty;

        [SerializeField]
        private LevelObjectScript[] requiredLevels = Array.Empty<LevelObjectScript>();

        public StringTranslationObjectScript LevelNameStringTranslation => levelNameStringTranslation;

        public string ScenePath => scenePath ?? string.Empty;

        public string LevelName => levelNameStringTranslation ? levelNameStringTranslation.ToString() : name;

        public IReadOnlyCollection<LevelObjectScript> RequiredLevels => requiredLevels ?? Array.Empty<LevelObjectScript>();
    }
}
