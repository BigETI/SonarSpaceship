using SonarSpaceship.Controllers;
using UnityEngine;

namespace SonarSpaceship
{
    public interface IPing
    {
        PingableControllerScript PingableController { get; }

        SpaceshipControllerScript IssuingSpaceshipController { get; }

        Vector2 StartPosition { get; }

        Vector2 Direction { get; }

        float Angle { get; }

        float MaximalDistance { get; }

        float TraveledDistance { get; }

        Vector2 LastPingableControllerPosition { get; }

        EPingResult ProcessPing(float deltaTime);
    }
}
