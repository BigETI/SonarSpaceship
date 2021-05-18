using System;
using UnityEngine;
using UnityEngine.Events;
using UnitySceneLoaderManager;

namespace SonarSpaceship.Controllers
{
    public class SpawnPointControllerScript : MonoBehaviour, ISpawnPointController
    {
        [SerializeField]
        private float startingFuel = 30.0f;

        [SerializeField]
        private UnityEvent onPlayerSpawned = default;

        [SerializeField]
        private UnityEvent onContainerDelivered = default;

        [SerializeField]
        private UnityEvent onLevelFinished = default;

        public float StartingFuel
        {
            get => startingFuel;
            set => startingFuel = Mathf.Max(value, 0.0f);
        }

        public PlayerControllerScript PlayerController { get; private set; }

        public event PlayerSpawnedDelegate OnPlayerSpawned;

        public event ContainerDeliveredDelegate OnContainerDelivered;

        public event LevelFinishedDelegate OnLevelFinished;

        public void SpawnPlayer()
        {
            if (PlayerController && PlayerController.TryGetComponent(out SpaceshipControllerScript spaceship_controller))
            {
                PlayerController.transform.position = transform.position;
                PlayerController.transform.rotation = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward);
                spaceship_controller.Fuel = startingFuel;
                if (onPlayerSpawned != null)
                {
                    onPlayerSpawned.Invoke();
                }
                OnPlayerSpawned?.Invoke(PlayerController);
                spaceship_controller.InvokeSpawnedEvent();
            }
        }

        public void CollectContainer(ContainerControllerScript containerController)
        {
            if (!containerController)
            {
                throw new ArgumentNullException(nameof(containerController));
            }
            if (onContainerDelivered != null)
            {
                onContainerDelivered.Invoke();
            }
            OnContainerDelivered?.Invoke(containerController);
            if (ContainerControllerScript.EnabledControllerCount <= 1)
            {
                GameManager.FinishCurrentLevel();
                if (onLevelFinished != null)
                {
                    onLevelFinished.Invoke();
                }
                OnLevelFinished?.Invoke();
            }
            Destroy(containerController.gameObject);
        }

        public void ShowLevelSelectionMenu() => SceneLoaderManager.LoadScenes("LevelSelectionMenuScene");

        private void OnValidate() => startingFuel = Mathf.Max(startingFuel, 0.0f);

        private void Start()
        {
            PlayerController = FindObjectOfType<PlayerControllerScript>();
            SpawnPlayer();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Matrix4x4 old_matrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one * 2.0f);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one * 1.5f);
            EntityGizmos.DrawArrow(Vector3.zero, 1.5f);
            Gizmos.matrix = old_matrix;
        }
#endif
    }
}
