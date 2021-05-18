using UnityAudioManager;
using UnityEngine;

namespace SonarSpaceship.Triggers
{
    public class MusicAudioVolumeTriggerScript : MonoBehaviour, IMusicAudioVolumeTrigger
    {
        [SerializeField]
        private float musicVolume = 1.0f;

        public float MusicVolume
        {
            get => musicVolume;
            set => musicVolume = Mathf.Clamp(value, 0.0f, 1.0f);
        }

        private void Start()
        {
            AudioManager.MusicVolume = musicVolume;
            Destroy(gameObject);
        }

#if UNITY_EDITOR
        private void OnValidate() => musicVolume = Mathf.Clamp(musicVolume, 0.0f, 1.0f);
#endif
    }
}
