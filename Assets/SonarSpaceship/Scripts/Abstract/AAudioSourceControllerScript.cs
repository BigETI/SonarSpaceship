using SonarSpaceship.Data;
using UnityEngine;
using UnitySaveGame;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AAudioSourceControllerScript : MonoBehaviour, IAudioSourceController
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

        protected virtual void Start()
        {
            if (TryGetComponent(out AudioSource thrust_audio_source))
            {
                AudioSource = thrust_audio_source;
            }
            else
            {
                Debug.LogError($"Please attach a \"{ nameof(UnityEngine.AudioSource) }\" component to this game object.", this);
            }
        }
    }
}
