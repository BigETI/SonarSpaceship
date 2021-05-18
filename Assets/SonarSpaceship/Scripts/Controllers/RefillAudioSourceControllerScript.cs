using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public class RefillAudioSourceControllerScript : ASpaceshipControllerAudioSourceControllerScript, IRefillAudioSourceController
    {
        [SerializeField]
        private float fadeInTime = 0.0625f;

        [SerializeField]
        private float fadeOutTime = 0.25f;

        public float FadeInTime
        {
            get => fadeInTime;
            set => fadeInTime = Mathf.Max(value, 0.0f);
        }

        public float FadeOutTime
        {
            get => fadeOutTime;
            set => fadeOutTime = Mathf.Max(value, 0.0f);
        }

        public float CurrentVolume { get; private set; }

        private void FixedUpdate()
        {
            if (AudioSource && SpaceshipController)
            {
                bool is_playing = false;
                if ((SpaceshipController.Fuel < SpaceshipController.MaximalFuelCapacity) && !IsMuted)
                {
                    foreach (RefillStationControllerScript docked_refill_station_controller in SpaceshipController.DockedRefillStationControllers)
                    {
                        if (docked_refill_station_controller.FuelCapacity > float.Epsilon)
                        {
                            is_playing = true;
                            break;
                        }
                    }
                }
                AudioSource.pitch = SpaceshipController.Fuel / SpaceshipController.MaximalFuelCapacity;
                if (is_playing)
                {
                    CurrentVolume = Mathf.Min(CurrentVolume + (Time.fixedDeltaTime / fadeInTime), 1.0f);
                    if (!AudioSource.isPlaying)
                    {
                        AudioSource.Play();
                    }
                }
                else
                {
                    CurrentVolume = Mathf.Max(CurrentVolume - (Time.fixedDeltaTime / fadeOutTime), 0.0f);
                    if ((CurrentVolume <= 0.0f) && AudioSource.isPlaying)
                    {
                        AudioSource.Stop();
                    }
                }
                AudioSource.volume = CurrentVolume;
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            fadeInTime = Mathf.Max(fadeInTime, 0.0f);
            fadeOutTime = Mathf.Max(fadeOutTime, 0.0f);
        }
#endif
    }
}
