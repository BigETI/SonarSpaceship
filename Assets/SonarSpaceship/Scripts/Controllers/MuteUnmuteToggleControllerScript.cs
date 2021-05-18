using SonarSpaceship.Data;
using UnityAudioManager;
using UnityEngine;
using UnityEngine.UI;
using UnitySaveGame;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(Toggle))]
    public class MuteUnmuteToggleControllerScript : MonoBehaviour, IMuteUnmuteToggleController
    {
        public Toggle MuteUnmuteToggle { get; private set; }

        private void ValueChangedEvent(bool value)
        {
            if (MuteUnmuteToggle)
            {
                SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
                if (save_game.Data != null)
                {
                    save_game.Data.IsMuted = value;
                    save_game.Save();
                }
            }
            AudioManager.IsMuted = value;
        }

        private void Start()
        {
            if (TryGetComponent(out Toggle mute_unmute_toggle))
            {
                MuteUnmuteToggle = mute_unmute_toggle;
                mute_unmute_toggle.onValueChanged.AddListener(ValueChangedEvent);
                SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
                if (save_game.Data != null)
                {
                    mute_unmute_toggle.SetIsOnWithoutNotify(save_game.Data.IsMuted);
                }
            }
            else
            {
                Debug.LogError($"Please attach a \"{ nameof(Toggle) }\" component to this game object.", this);
            }
        }

        private void OnDestroy()
        {
            if (MuteUnmuteToggle)
            {
                MuteUnmuteToggle.onValueChanged.RemoveListener(ValueChangedEvent);
            }
        }
    }
}
