using System;
using UnityAudioManager;
using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public class SoundEffectPlayerControllerScript : MonoBehaviour, ISoundEffectPlayerController
    {
        public void Play(AudioClip audioClip)
        {
            if (!audioClip)
            {
                throw new ArgumentNullException(nameof(audioClip));
            }
            AudioManager.PlaySoundEffect(audioClip);
        }
    }
}
