using SonarSpaceship.Objects;
using System.Collections.Generic;

namespace SonarSpaceship
{
    public interface IProfile
    {
        byte ProfileIndex { get; }

        string Name { get; }

        IEnumerable<string> FinishedLevelNames { get; }

        bool IsLevelFinished(LevelObjectScript level);

        bool FinishLevel(LevelObjectScript level);

        bool RevertFinishingLevel(LevelObjectScript level);

        void ClearFinishedLevels();

        bool Save();
    }
}
