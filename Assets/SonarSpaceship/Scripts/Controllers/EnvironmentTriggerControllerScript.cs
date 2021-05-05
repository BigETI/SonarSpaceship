using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SonarSpaceship.Controllers
{
    public class EnvironmentTriggerControllerScript : MonoBehaviour, IEnvironmentTriggerController
    {
        [SerializeField]
        private bool isAbleToTriggerMultipleTimes;

        [SerializeField]
        private bool isOnlyTriggeringForPlayers;

        [SerializeField]
        private UnityEvent onTriggerEntered = default;

        [SerializeField]
        private UnityEvent onTriggerExited = default;

        private Dictionary<int, SpaceshipControllerScript> enteredSpaceshipControllers = new Dictionary<int, SpaceshipControllerScript>();

        public bool IsAbleToTriggerMultipleTimes
        {
            get => isAbleToTriggerMultipleTimes;
            set => isAbleToTriggerMultipleTimes = value;
        }

        public bool IsOnlyTriggeringForPlayers
        {
            get => isOnlyTriggeringForPlayers;
            set => isOnlyTriggeringForPlayers = value;
        }

        public bool IsTriggered { get; private set; }

        public IReadOnlyCollection<SpaceshipControllerScript> EnteredSpaceshipControllers => enteredSpaceshipControllers.Values;

        public event TriggerEnteredDelegate OnTriggerEntered;

        public event TriggerExitedDelegate OnTriggerExited;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            int id = collider.gameObject.GetInstanceID();
            if ((!IsTriggered || isAbleToTriggerMultipleTimes) && !enteredSpaceshipControllers.ContainsKey(id) && collider.GetComponentInParent<SpaceshipControllerScript>() is SpaceshipControllerScript spaceship_controller)
            {
                if (!isOnlyTriggeringForPlayers || spaceship_controller.TryGetComponent<PlayerControllerScript>(out _))
                {
                    enteredSpaceshipControllers.Add(id, spaceship_controller);
                    IsTriggered = true;
                    if (onTriggerEntered != null)
                    {
                        onTriggerEntered.Invoke();
                    }
                    OnTriggerEntered?.Invoke(spaceship_controller);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            int id = collider.gameObject.GetInstanceID();
            if (enteredSpaceshipControllers.TryGetValue(id, out SpaceshipControllerScript spaceship_controller))
            {
                enteredSpaceshipControllers.Remove(id);
                if (onTriggerExited != null)
                {
                    onTriggerExited.Invoke();
                }
                OnTriggerExited?.Invoke(spaceship_controller);
            }
        }
    }
}
