using SonarSpaceship.Controllers;

namespace SonarSpaceship
{
    public interface ISpaceshipControllerAudioSourceController : IAudioSourceController
    {
        SpaceshipControllerScript SpaceshipController { get; }
    }
}
