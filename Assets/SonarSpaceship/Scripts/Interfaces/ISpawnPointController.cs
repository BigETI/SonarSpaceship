using SonarSpaceship.Controllers;

namespace SonarSpaceship
{
    public interface ISpawnPointController : IBehaviour
    {
        PlayerControllerScript PlayerController { get; }

        event PlayerSpawnedDelegate OnPlayerSpawned;

        event ContainerDeliveredDelegate OnContainerDelivered;

        event LevelFinishedDelegate OnLevelFinished;

        void SpawnPlayer();
    }
}
