using System;
using UnityEngine;
using UnityEngine.Events;

namespace SonarSpaceship.Controllers
{
    public class PingableControllerScript : MonoBehaviour, IPingableController
    {
        [SerializeField]
        private UnityEvent onPingReceived = default;

        public event PingReceivedDelegate OnPingReceived;

        public virtual void ReceivePing(SpaceshipControllerScript spaceshipController)
        {
            if (!spaceshipController)
            {
                throw new ArgumentNullException(nameof(spaceshipController));
            }
            if (onPingReceived != null)
            {
                onPingReceived.Invoke();
            }
            OnPingReceived?.Invoke(spaceshipController);
        }
    }
}
