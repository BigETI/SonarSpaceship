using SonarSpaceship.Data;
using UnityEngine;
using UnitySaveGame;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceActivityControllerScript : MonoBehaviour, IAudioSourceActivityController
    {
        public AudioSource AudioSource { get; private set; }

        public bool IsMuted
        {
            get
            {
                SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
                return (save_game.Data != null) && save_game.Data.IsMuted;
            }
        }

        private void UpdateActivity()
        {
            if (AudioSource)
            {
                SaveGame<SaveGameData> save_game = SaveGames.Get<SaveGameData>();
                if ((save_game.Data != null) && save_game.Data.IsMuted && AudioSource.isPlaying)
                {
                    AudioSource.Stop();
                }
            }
        }

        public void Play()
        {
            if (AudioSource && !IsMuted)
            {
                AudioSource.Play();
            }
        }

        private void Start()
        {
            if (TryGetComponent(out AudioSource audio_source))
            {
                AudioSource = audio_source;
                UpdateActivity();
            }
            else
            {
                Debug.LogError($"Please attach a \"{ nameof(UnityEngine.AudioSource) }\" component to this game object.", this);
            }
        }

        private void FixedUpdate() => UpdateActivity();
    }
}
