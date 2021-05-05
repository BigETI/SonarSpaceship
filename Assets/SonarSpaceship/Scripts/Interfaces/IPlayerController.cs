using SonarSpaceship.Controllers;
using SonarSpaceship.InputActions;
using UnityEngine;

namespace SonarSpaceship
{
    public interface IPlayerController : IBehaviour
    {
        SpaceshipControllerScript SpaceshipController { get; }

        GameInputActions GameInputActions { get; }

        Camera GameCamera { get; }
    }
}
