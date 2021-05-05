using UnityTranslator.Objects;

namespace SonarSpaceship
{
    public interface ILevelObject : IScriptableObject
    {
        StringTranslationObjectScript LevelNameStringTranslation { get; }

        string ScenePath { get; }

        string LevelName { get; }
    }
}
