namespace SonarSpaceship
{
    public interface IRefillAudioSourceController : ISpaceshipControllerAudioSourceController
    {
        float FadeInTime { get; set; }

        float FadeOutTime { get; set; }

        float CurrentVolume { get; }
    }
}
