using SonarSpaceship.Data;
using System.Collections.Generic;

namespace SonarSpaceship
{
    public interface ISaveGameData
    {
        IReadOnlyList<ProfileData> Profiles { get; }

        bool IsProfileAvailable(byte profileIndex);

        IProfileData CreateNewProfile(byte profileIndex, string name);

        IProfileData LoadProfile(byte profileIndex);

        void WriteProfile(byte profileIndex, string name, IEnumerable<string> finishedLevels);

        bool RemoveProfile(byte profileIndex);
    }
}
