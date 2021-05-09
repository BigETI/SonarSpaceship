using SonarSpaceship.Data;
using SonarSpaceship.Objects;
using System;
using System.Collections.Generic;
using UnitySaveGame;

namespace SonarSpaceship
{
    internal class Profile : IProfile
    {
        private readonly HashSet<string> finishedLevelNames = new HashSet<string>();

        public byte ProfileIndex { get; }

        public string Name { get; }

        public IEnumerable<string> FinishedLevelNames => finishedLevelNames;

        public Profile(byte profileIndex, string name, IEnumerable<string> finishedLevelNames)
        {
            ProfileIndex = profileIndex;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            this.finishedLevelNames.UnionWith(finishedLevelNames ?? throw new ArgumentNullException(nameof(finishedLevelNames)));
        }

        public bool IsLevelFinished(LevelObjectScript level)
        {
            if (!level)
            {
                throw new ArgumentNullException(nameof(level));
            }
            return finishedLevelNames.Contains(level.name);
        }

        public bool FinishLevel(LevelObjectScript level)
        {
            if (!level)
            {
                throw new ArgumentNullException(nameof(level));
            }
            return finishedLevelNames.Add(level.name);
        }

        public bool RevertFinishingLevel(LevelObjectScript level)
        {
            if (!level)
            {
                throw new ArgumentNullException(nameof(level));
            }
            return finishedLevelNames.Remove(level.name);
        }

        public void ClearFinishedLevels() => finishedLevelNames.Clear();

        public bool Save()
        {
            bool ret = false;
            SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
            if (save_game != null)
            {
                save_game.Data.WriteProfile(ProfileIndex, Name, finishedLevelNames);
                ret = save_game.Save();
            }
            return ret;
        }
    }
}
