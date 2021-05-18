using SonarSpaceship.Data;
using UnityAudioManager;
using UnityEngine;
using UnitySaveGame;

namespace SonarSpaceship.Triggers
{
    public class AudioSettingsTriggerScript : MonoBehaviour, IAudioSettingsTrigger
    {
        private void LateUpdate()
        {
            SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
            if (save_game.Data != null)
            {
                AudioManager.IsMuted = save_game.Data.IsMuted;
            }
            Destroy(this);
        }
    }
}
