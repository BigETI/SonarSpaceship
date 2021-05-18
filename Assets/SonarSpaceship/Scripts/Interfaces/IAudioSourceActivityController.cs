using UnityEngine;

namespace SonarSpaceship
{
    public interface IAudioSourceActivityController : IBehaviour
    {
        AudioSource AudioSource { get; }

        bool IsMuted { get; }

        void Play();
    }
}
