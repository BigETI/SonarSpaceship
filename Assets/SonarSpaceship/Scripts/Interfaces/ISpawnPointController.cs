using SonarSpaceship.Controllers;

namespace SonarSpaceship
{
    public interface ISpawnPointController : IBehaviour
    {
        float StartingFuel { get; set; }

        PlayerControllerScript PlayerController { get; }

        event PlayerSpawnedDelegate OnPlayerSpawned;

        event ContainerDeliveredDelegate OnContainerDelivered;

        event LevelFinishedDelegate OnLevelFinished;

        void SpawnPlayer();
    }
}
