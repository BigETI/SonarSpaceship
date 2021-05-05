﻿using UnityEngine;
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

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Matrix4x4 old_matrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            EntityGizmos.DrawArrow(Vector3.zero, 1.0f);
            Gizmos.matrix = old_matrix;
        }
#endif
    }
}
