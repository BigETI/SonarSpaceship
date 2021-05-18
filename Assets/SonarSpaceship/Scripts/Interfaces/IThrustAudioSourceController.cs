namespace SonarSpaceship
{
    public interface IThrustAudioSourceController : ISpaceshipControllerAudioSourceController
    {
        float VolumeGainLooseSpeed { get; set; }

        float CurrentVolume { get; }
    }
}
