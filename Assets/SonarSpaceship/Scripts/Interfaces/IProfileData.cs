using System.Collections.Generic;

namespace SonarSpaceship
{
    public interface IProfileData
    {
        string Name { get; }

        IEnumerable<string> FinishedLevels { get; }
    }
}
