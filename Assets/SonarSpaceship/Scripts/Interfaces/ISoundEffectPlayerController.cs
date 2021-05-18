using UnityEngine;

namespace SonarSpaceship
{
    public interface ISoundEffectPlayerController : IBehaviour
    {
        void Play(AudioClip audioClip);
    }
}
