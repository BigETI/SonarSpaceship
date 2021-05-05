using System;
using UnityEngine;
using UnityEngine.Events;

namespace SonarSpaceship.Controllers
{
    public class SpawnPointControllerScript : MonoBehaviour, ISpawnPointController
    {
        [SerializeField]
        private UnityEvent onPlayerSpawned = default;

        [SerializeField]
        private UnityEvent onContainerDelivered = default;

        [SerializeField]
        private UnityEvent onLevelFinished = default;

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
            if (FindObjectsOfType<ContainerControllerScript>().Length <= 1)
            {
                if (onLevelFinished != null)
                {
                    onLevelFinished.Invoke();
                }
                OnLevelFinished?.Invoke();
                Debug.Log("Finished!");
                // TODO: Notify game manager that level has been finished.
            }
            Destroy(containerController.gameObject);
        }

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
