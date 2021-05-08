using UnityEngine;
using UnityEngine.Events;

namespace SonarSpaceship.Controllers
{
    public class CollidableControllerScript : MonoBehaviour, ICollidableController
    {
        [SerializeField]
        private float maximalDamage = 15.0f;

        [SerializeField]
        private bool isExplosive;

        [SerializeField]
        private float bounciness = 1.0f;

        [SerializeField]
        private UnityEvent onCollided = default;

        public float MaximalDamage
        {
            get => maximalDamage;
            set => maximalDamage = Mathf.Max(value, 0.0f);
        }

        public bool IsExplosive
        {
            get => isExplosive;
            set => isExplosive = value;
        }

        public float Bounciness
        {
            get => bounciness;
            set => bounciness = Mathf.Max(value, 0.0f);
        }

        public void Collide()
        {
            if (onCollided != null)
            {
                onCollided.Invoke();
            }
            OnCollided?.Invoke();
        }

        public event CollidedDelegate OnCollided;

        private void OnValidate()
        {
            bounciness = Mathf.Max(bounciness, 0.0f);
            maximalDamage = Mathf.Max(maximalDamage, 0.0f);
        }

        private void OnCollisionEnter2D(Collision2D collision) => Collide();

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Matrix4x4 old_matrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireSphere(Vector3.zero, 0.5f);
            EntityGizmos.DrawArrow(Vector3.zero, 1.0f);
            Gizmos.matrix = old_matrix;
        }
#endif
    }
}
