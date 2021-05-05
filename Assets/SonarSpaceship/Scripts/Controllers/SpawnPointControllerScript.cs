using System;
using UnityEngine;
using UnityEngine.Events;

namespace SonarSpaceship.Controllers
{
    public class SpawnPointControllerScript : MonoBehaviour, ISpawnPointController
    {
#if UNITY_EDITOR
        [SerializeField]
        private float gizmoRadius = 1.0f;
#endif

        [SerializeField]
        private UnityEvent onPlayerSpawned = default;

        [SerializeField]
        private UnityEvent onContainerDelivered = default;

        [SerializeField]
        private UnityEvent onLevelFinished = default;

#if UNITY_EDITOR
        public float GizmoRadius
        {
            get => gizmoRadius;
            set => gizmoRadius = Mathf.Max(value, 0.0f);
        }
#endif

        public PlayerControllerScript PlayerController { get; private set; }

        public event PlayerSpawnedDelegate OnPlayerSpawned;

        public event ContainerDeliveredDelegate OnContainerDelivered;

        public event LevelFinishedDelegate OnLevelFinished;

#if UNITY_EDITOR
        private void OnValidate() => gizmoRadius = Mathf.Max(gizmoRadius, 0.0f);
#endif

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
            Vector3 position = transform.position;
            Quaternion rotation = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward);
            Vector3 top_position = position + (rotation * Vector3.up * 0.5f);
            Gizmos.DrawWireSphere(position, gizmoRadius);
            Gizmos.DrawWireSphere(position, gizmoRadius * 0.75f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(position - (rotation * Vector3.up * 0.5f), top_position);
            Gizmos.DrawLine(top_position, position - (rotation * Vector3.left * 0.25f));
            Gizmos.DrawLine(top_position, position - (rotation * Vector3.right * 0.25f));
        }
#endif
    }
}
