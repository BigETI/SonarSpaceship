using UnityEngine;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(AudioSource))]
    public class ThrustAudioSourceControllerScript : ASpaceshipControllerAudioSourceControllerScript, IThrustAudioSourceController
    {
        [SerializeField]
        private float volumeGainLooseSpeed = 2.0f;

        public float VolumeGainLooseSpeed
        {
            get => volumeGainLooseSpeed;
            set => volumeGainLooseSpeed = Mathf.Max(value, 0.0f);
        }

        public float CurrentVolume { get; private set; }

        private void FixedUpdate()
        {
            if (AudioSource && SpaceshipController)
            {
                float volume = 0.0f;
                if ((SpaceshipController.Fuel > float.Epsilon) && !IsMuted)
                {
                    volume = SpaceshipController.Movement.magnitude;
                }
                if (CurrentVolume > volume)
                {
                    CurrentVolume -= Time.fixedDeltaTime * volumeGainLooseSpeed;
                    if (CurrentVolume < volume)
                    {
                        CurrentVolume = volume;
                    }
                }
                else if (CurrentVolume < volume)
                {
                    CurrentVolume += Time.fixedDeltaTime * volumeGainLooseSpeed;
                    if (CurrentVolume > volume)
                    {
                        CurrentVolume = volume;
                    }
                }
                AudioSource.volume = CurrentVolume;
                if ((CurrentVolume <= float.Epsilon) && AudioSource.isPlaying)
                {
                    AudioSource.Stop();
                }
                else if ((CurrentVolume > float.Epsilon) && !AudioSource.isPlaying)
                {
                    AudioSource.Play();
                }
            }
        }

#if UNITY_EDITOR
        private void OnValidate() => volumeGainLooseSpeed = Mathf.Max(volumeGainLooseSpeed, 0.0f);
#endif
    }
}
