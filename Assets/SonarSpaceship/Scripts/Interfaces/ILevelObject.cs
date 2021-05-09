using SonarSpaceship.Objects;
using System.Collections.Generic;
using UnityTranslator.Objects;

namespace SonarSpaceship
{
    public interface ILevelObject : IScriptableObject
    {
        StringTranslationObjectScript LevelNameStringTranslation { get; }

        string ScenePath { get; }

        IReadOnlyCollection<LevelObjectScript> RequiredLevels { get; }
    }
}
