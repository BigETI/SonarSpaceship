using UnityEngine;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EvilEntityControllerScript : AControllersControllerScript<EvilEntityControllerScript>, IEvilEntityController
    {
        [SerializeField]
        private bool isMovingAway;

        [SerializeField]
        private float maximalAccelerationForce = 20.0f;

        [SerializeField]
        private float maximalSpeed = 5.0f;

        [SerializeField]
        private float attackRadius = 10.0f;

        [SerializeField]
        private float avoidanceDistance = 2.0f;

        public bool IsMovingAway
        {
            get => isMovingAway;
            set => isMovingAway = value;
        }

        public float MaximalAccelerationForce
        {
            get => maximalAccelerationForce;
            set => maximalAccelerationForce = Mathf.Max(value, 0.0f);
        }

        public float MaximalSpeed
        {
            get => maximalSpeed;
            set => maximalSpeed = Mathf.Max(value, 0.0f);
        }

        public float AttackRadius
        {
            get => attackRadius;
            set => attackRadius = Mathf.Max(value, 0.0f);
        }

        public float AvoidanceDistance
        {
            get => avoidanceDistance;
            set => avoidanceDistance = Mathf.Max(value, 0.0f);
        }

        public Vector2 MovingAtDirection { get; private set; }

        public Rigidbody2D EvilEntityRigidBody { get; private set; }

        private void Start()
        {
            if (TryGetComponent(out Rigidbody2D evil_entity_rigid_body))
            {
                EvilEntityRigidBody = evil_entity_rigid_body;
            }
            else
            {
                Debug.LogError($"Please attach a \"{ nameof(Rigidbody2D) }\" component to this game object.", this);
            }
        }

        private void Update()
        {
            if (EvilEntityRigidBody)
            {
                Vector2 direction_sum = Vector2.zero;
                uint count = 0U;
                Vector3 world_position = transform.position;
                Vector2 position = new Vector2(world_position.x, world_position.y);
                Vector2 velocity = EvilEntityRigidBody.velocity;
                foreach (SpaceshipControllerScript spaceship_controller in SpaceshipControllerScript.EnabledControllers)
                {
                    Vector3 spaceship_world_position = spaceship_controller.transform.position;
                    Vector2 spaceship_position = new Vector2(spaceship_world_position.x, spaceship_world_position.y);
                    Vector2 delta = isMovingAway ? (position - spaceship_position) : (spaceship_position - position);
                    float distance = delta.magnitude;
                    if ((distance <= attackRadius) && (distance > float.Epsilon))
                    {
                        direction_sum += delta / distance;
                        ++count;
                    }
                }
                foreach (EvilEntityControllerScript evil_entity_controller in EnabledControllers)
                {
                    if (gameObject.GetInstanceID() != evil_entity_controller.gameObject.GetInstanceID())
                    {
                        Vector3 evil_entity_world_position = evil_entity_controller.transform.position;
                        Vector2 evil_entity_position = new Vector2(evil_entity_world_position.x, evil_entity_world_position.y);
                        Vector2 delta = position - evil_entity_position;
                        float distance = delta.magnitude;
                        if ((distance <= avoidanceDistance) && (distance > float.Epsilon))
                        {
                            direction_sum += delta / distance;
                            ++count;
                        }
                    }
                }
                if (count > 0U)
                {
                    MovingAtDirection = direction_sum / count;
                    velocity += MovingAtDirection * (maximalAccelerationForce / EvilEntityRigidBody.mass) * Time.deltaTime;
                }
                else if (velocity.sqrMagnitude > float.Epsilon)
                {
                    Vector2 subtract_velocity = velocity.normalized * (maximalAccelerationForce / EvilEntityRigidBody.mass) * Time.deltaTime;
                    velocity = (subtract_velocity.sqrMagnitude < velocity.sqrMagnitude) ? (velocity - subtract_velocity) : Vector2.zero;
                }
                if (velocity.sqrMagnitude > (maximalSpeed * maximalSpeed))
                {
                    velocity = velocity.normalized * maximalSpeed;
                }
                EvilEntityRigidBody.velocity = velocity;
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            maximalAccelerationForce = Mathf.Max(maximalAccelerationForce, 0.0f);
            maximalSpeed = Mathf.Max(maximalSpeed, 0.0f);
            attackRadius = Mathf.Max(attackRadius, 0.0f);
            avoidanceDistance = Mathf.Max(avoidanceDistance, 0.0f);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = isMovingAway ? Color.cyan : Color.magenta;
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }
#endif
    }
}
