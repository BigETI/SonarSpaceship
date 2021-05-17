using SonarSpaceship.Controllers;
using SonarSpaceship.InputActions;
using UnityEngine;

namespace SonarSpaceship
{
    public interface IPlayerController : IBehaviour
    {
        float MaximalTouchMovementDistance { get; set; }

        bool IsTouchscreenPressing { get; }

        Vector2 TouchMovement { get; }

        SpaceshipControllerScript SpaceshipController { get; }

        GameInputActions GameInputActions { get; }

        Camera GameCamera { get; }
    }
}
