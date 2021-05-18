using UnityEngine;

namespace SonarSpaceship
{
    public interface IAudioSourceController : IBehaviour
    {
        AudioSource AudioSource { get; }

        bool IsMuted { get; }
    }
}
