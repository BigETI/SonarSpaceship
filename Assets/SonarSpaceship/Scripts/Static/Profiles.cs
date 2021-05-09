using SonarSpaceship.Data;
using System;
using UnitySaveGame;

namespace SonarSpaceship
{
    public static class Profiles
    {
        public static bool IsProfileAvailable(byte profileIndex)
        {
            bool ret = false;
            SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
            if (save_game.Data != null)
            {
                ret = save_game.Data.IsProfileAvailable(profileIndex);
            }
            return ret;
        }

        public static IProfile CreateNewProfile(byte profileIndex, string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            IProfile ret = null;
            SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
            if (save_game.Data != null)
            {
                IProfileData profile_data = save_game.Data.CreateNewProfile(profileIndex, name);
                if (profile_data != null)
                {
                    ret = new Profile(profileIndex, profile_data.Name, profile_data.FinishedLevels);
                    ret.Save();
                }
            }
            return ret;
        }

        public static IProfile LoadProfile(byte profileIndex)
        {
            IProfile ret = null;
            SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
            if (save_game.Data != null)
            {
                IProfileData profile_data = save_game.Data.LoadProfile(profileIndex);
                if (profile_data != null)
                {
                    ret = new Profile(profileIndex, profile_data.Name, profile_data.FinishedLevels);
                }
            }
            return ret;
        }

        public static bool RemoveProfile(byte profileIndex)
        {
            bool ret = false;
            SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
            if (save_game.Data != null)
            {
                ret = save_game.Data.RemoveProfile(profileIndex);
            }
            return ret;
        }
    }
}
