using SonarSpaceship.Controllers;

namespace SonarSpaceship
{
    public interface ISpawnPointController : IBehaviour
    {
#if UNITY_EDITOR
        float GizmoRadius { get; set; }
#endif

        PlayerControllerScript PlayerController { get; }

        event PlayerSpawnedDelegate OnPlayerSpawned;

        event ContainerDeliveredDelegate OnContainerDelivered;

        event LevelFinishedDelegate OnLevelFinished;

        void SpawnPlayer();
    }
}
