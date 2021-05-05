using UnityEngine;
using UnityEngine.Events;

namespace SonarSpaceship.Controllers
{
    public class ContainerControllerScript : MonoBehaviour, IContainerController
    {
        [SerializeField]
        private UnityEvent onAttached = default;

        [SerializeField]
        private UnityEvent onDetached = default;

        public event AttachedDelegate OnAttached;

        public event DetachedDelegate OnDetached;

        public void InvokeAttachedEvent()
        {
            if (onAttached != null)
            {
                onAttached.Invoke();
            }
            OnAttached?.Invoke();
        }

        public void InvokeDetachedEvent()
        {
            if (onDetached != null)
            {
                onDetached.Invoke();
            }
            OnDetached?.Invoke();
        }
    }
}
