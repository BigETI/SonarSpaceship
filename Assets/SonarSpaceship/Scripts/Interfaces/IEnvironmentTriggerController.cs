using SonarSpaceship.Controllers;
using System.Collections.Generic;

namespace SonarSpaceship
{
    public interface IEnvironmentTriggerController : IBehaviour
    {
        bool IsAbleToTriggerMultipleTimes { get; set; }

        bool IsOnlyTriggeringForPlayers { get; set; }

        bool IsTriggered { get; }

        IReadOnlyCollection<SpaceshipControllerScript> EnteredSpaceshipControllers { get; }

        event TriggerEnteredDelegate OnTriggerEntered;

        event TriggerExitedDelegate OnTriggerExited;

    }
}
