using SonarSpaceship.Objects;
using System.Collections.Generic;
using UnityTranslator.Objects;

namespace SonarSpaceship
{
    public interface ISectorObject : IScriptableObject
    {
        StringTranslationObjectScript SectorNameStringTranslation { get; }

        string SectorName { get; }

        IReadOnlyCollection<LevelObjectScript> Levels { get; }
    }
}
