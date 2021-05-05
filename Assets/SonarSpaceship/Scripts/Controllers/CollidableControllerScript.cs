using UnityEngine;
using UnityEngine.Events;

namespace SonarSpaceship.Controllers
{
    public class CollidableControllerScript : MonoBehaviour, ICollidableController
    {
        [SerializeField]
        private float bounciness = 1.0f;

        [SerializeField]
        private UnityEvent onCollided = default;

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

        private void OnValidate() => bounciness = Mathf.Max(bounciness, 0.0f);

        private void OnCollisionEnter2D(Collision2D collision) => Collide();
    }
}
