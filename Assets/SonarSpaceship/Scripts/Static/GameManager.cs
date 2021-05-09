using SonarSpaceship.Objects;
using System;
using UnitySceneLoaderManager;

namespace SonarSpaceship
{
    public static class GameManager
    {
        private static byte selectedProfileIndex;

        private static IProfile selectedProfile;

        public static byte SelectedProfileIndex
        {
            get => selectedProfileIndex;
            set
            {
                if (selectedProfileIndex != value)
                {
                    selectedProfileIndex = value;
                    selectedProfile = Profiles.LoadProfile(selectedProfileIndex);
                }
            }
        }

        public static IProfile SelectedProfile => selectedProfile ??= Profiles.LoadProfile(selectedProfileIndex);

        public static LevelObjectScript SelectedLevel { get; private set; }

        public static void ReloadSelectedProfile() => selectedProfile = Profiles.LoadProfile(selectedProfileIndex);

        public static IScenesLoadingState LoadLevel(LevelObjectScript level)
        {
            if (!level)
            {
                throw new ArgumentNullException(nameof(level));
            }
            SelectedLevel = level;
            return SceneLoaderManager.LoadScenes("GameScene", level.ScenePath);
        }

        public static bool FinishCurrentLevel() => SelectedLevel && SelectedProfile is IProfile selected_profile && selected_profile.FinishLevel(SelectedLevel) && selected_profile.Save();
    }
}
