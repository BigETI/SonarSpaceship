using System;
using System.Collections.Generic;
using UnityEngine;
using UnityTranslator.Objects;

namespace SonarSpaceship.Objects
{
    [CreateAssetMenu(fileName = "Sector", menuName = "Sonar Spaceship/Sector")]
    public class SectorObjectScript : ScriptableObject, ISectorObject
    {
        [SerializeField]
        private StringTranslationObjectScript sectorNameStringTranslation = default;

        [SerializeField]
        private LevelObjectScript[] levels = Array.Empty<LevelObjectScript>();

        public StringTranslationObjectScript SectorNameStringTranslation => sectorNameStringTranslation;

        public string SectorName => sectorNameStringTranslation ? sectorNameStringTranslation.ToString() : name;

        public IReadOnlyCollection<LevelObjectScript> Levels => levels ?? Array.Empty<LevelObjectScript>();
    }
}
