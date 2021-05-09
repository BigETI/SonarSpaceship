using System;
using System.Collections.Generic;
using UnityEngine;
using UnitySaveGame;

namespace SonarSpaceship.Data
{
    [Serializable]
    internal class SaveGameData : ASaveGameData, ISaveGameData
    {
        [SerializeField]
        private ProfileData[] profiles = Array.Empty<ProfileData>();

        public IReadOnlyList<ProfileData> Profiles => profiles ?? Array.Empty<ProfileData>();

        public SaveGameData() : base(null)
        {
            // ...
        }

        public SaveGameData(ASaveGameData saveGameData) : base(saveGameData)
        {
            if (saveGameData is SaveGameData save_game_data)
            {
                if (save_game_data.profiles != null)
                {
                    profiles = new ProfileData[save_game_data.profiles.Length];
                    for (int index = 0; index < profiles.Length; index++)
                    {
                        profiles[index] = save_game_data.profiles[index]?.Clone();
                    }
                    FixProfilesSize();
                }
            }
        }

        private void FixProfilesSize()
        {
            int last_index = profiles.Length - 1;
            if (last_index > 0xFF)
            {
                last_index = 0xFF;
            }
            for (; last_index >= 0; last_index--)
            {
                if (profiles[last_index] != null)
                {
                    break;
                }
            }
            int maximal_length = last_index + 1;
            if (profiles.Length != maximal_length)
            {
                Array.Resize(ref profiles, maximal_length);
            }
        }

        public bool IsProfileAvailable(byte profileIndex) => (profiles != null) && (profileIndex < profiles.Length) && (profiles[profileIndex] != null);

        public IProfileData CreateNewProfile(byte profileIndex, string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            profiles ??= Array.Empty<ProfileData>();
            if (profileIndex >= profiles.Length)
            {
                Array.Resize(ref profiles, profileIndex + 1);
            }
            ref ProfileData ret = ref profiles[profileIndex];
            ret = new ProfileData
            {
                Name = name
            };
            return ret;
        }

        public IProfileData LoadProfile(byte profileIndex) => ((profiles != null) && (profileIndex < profiles.Length)) ? profiles[profileIndex] : null;

        public void WriteProfile(byte profileIndex, string name, IEnumerable<string> finishedLevels)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (finishedLevels == null)
            {
                throw new ArgumentNullException(nameof(finishedLevels));
            }
            profiles ??= Array.Empty<ProfileData>();
            if (profileIndex >= profiles.Length)
            {
                Array.Resize(ref profiles, profileIndex + 1);
            }
            profiles[profileIndex] = new ProfileData(name, finishedLevels);
        }

        public bool RemoveProfile(byte profileIndex)
        {
            bool ret = false;
            if ((profiles != null) && (profileIndex < profiles.Length))
            {
                ref ProfileData profile = ref profiles[profileIndex];
                ret = profile != null;
                if (ret)
                {
                    profile = null;
                    FixProfilesSize();
                }
            }
            return ret;
        }
    }
}
