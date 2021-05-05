using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceshipControllerScript : MonoBehaviour, ISpaceshipController
    {
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float lookAtSmoothing = 0.125f;

        [SerializeField]
        private float maximalAccelerationForce = 10.0f;

        [SerializeField]
        private float maximalSpeed = 5.0f;

        [SerializeField]
        private float inertiaDampenerForce = 5.0f;

        [SerializeField]
        private float weight = 1.0f;

        [SerializeField]
        private float emssSpeed = 10.0f;

        [SerializeField]
        private float emssDistance = 100.0f;

        [SerializeField]
        private float emssAngle = 20.0f;

        [SerializeField]
        private float maximalAttachmentCooldownTime = 1.0f;

        [SerializeField]
        private UnityEvent onSpawned = default;

        [SerializeField]
        private UnityEvent onPinged = default;

        [SerializeField]
        private UnityEvent onContainerAttached = default;

        [SerializeField]
        private UnityEvent onContainerDetached = default;

        private Vector2 movement;

        private Vector2 lookAt = Vector2.up;

        private Vector2 lookingAt = Vector2.up;

        private List<(PingableControllerScript, float)> pinging = new List<(PingableControllerScript, float)>();

        public float LookAtSmoothing
        {
            get => lookAtSmoothing;
            set => lookAtSmoothing = Mathf.Clamp(value, 0.0f, 1.0f);
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

        public float InertiaDampenerForce
        {
            get => inertiaDampenerForce;
            set => inertiaDampenerForce = Mathf.Max(value, 0.0f);
        }

        public float Weight
        {
            get => weight;
            set => weight = Mathf.Max(value, float.Epsilon);
        }

        public float EMSSSpeed
        {
            get => emssSpeed;
            set => emssSpeed = Mathf.Max(value, 0.0f);
        }

        public float EMSSDistance
        {
            get => emssDistance;
            set => emssDistance = Mathf.Max(value, 0.0f);
        }

        public float EMSSAngle
        {
            get => emssAngle;
            set => emssAngle = Mathf.Repeat(value, 360.0f - float.Epsilon);
        }

        public Vector2 Movement
        {
            get => movement;
            set => movement = (value.sqrMagnitude < 1.0f) ? value : value.normalized;
        }

        public float MaximalAttachmentCooldownTime
        {
            get => maximalAttachmentCooldownTime;
            set => maximalAttachmentCooldownTime = Mathf.Max(value, 0.0f);
        }

        public Vector2 LookAt
        {
            get => lookAt;
            set
            {
                if (value.sqrMagnitude > float.Epsilon)
                {
                    lookAt = value.normalized;
                }
            }
        }

        public ContainerControllerScript AttachedContainerController { get; private set; }

        public float AttachmentCooldownTime { get; private set; }

        public Rigidbody2D SpaceshipRigidBody { get; private set; }

        private Vector2 ClampVelocity(Vector2 velocity) => (velocity.sqrMagnitude > (maximalSpeed * maximalSpeed)) ? (velocity.normalized * maximalSpeed) : velocity;

        public event SpawnedDelegate OnSpawned;

        public event PingedDelegate OnPinged;

        public event ContainerAttachedDelegate OnContainerAttached;

        public event ContainerDetachedDelegate OnContainerDetached;
        
        public void Ping()
        {
            PingableControllerScript[] pingable_controllers = FindObjectsOfType<PingableControllerScript>();
            Vector3 position = transform.position;
            float half_emss_angle = emssAngle * 0.5f;
            foreach (PingableControllerScript pingable_controller in pingable_controllers)
            {
                Vector3 delta = pingable_controller.transform.position - position;
                if (delta.sqrMagnitude > float.Epsilon)
                {
                    float distance = delta.magnitude;
                    Vector3 normal = delta / distance;
                    if ((distance <= emssDistance) && (Vector3.Angle(new Vector3(lookingAt.x, lookingAt.y, 0.0f), normal) <= half_emss_angle))
                    {
                        pinging.Add((pingable_controller, distance / emssSpeed));
                    }
                }
                else
                {
                    pingable_controller.ReceivePing(this);
                }
            }
            if (onPinged != null)
            {
                onPinged.Invoke();
            }
            OnPinged?.Invoke();
        }

        public void DetachContainer()
        {
            if (AttachedContainerController)
            {
                ContainerControllerScript attached_container_controller = AttachedContainerController;
                attached_container_controller.transform.SetParent(null, true);
                AttachedContainerController = null;
                AttachmentCooldownTime = maximalAttachmentCooldownTime;
                if (onContainerDetached != null)
                {
                    onContainerDetached.Invoke();
                }
                OnContainerDetached?.Invoke(attached_container_controller);
                attached_container_controller.InvokeAttachedEvent();
            }
        }

        public void InvokeSpawnedEvent()
        {
            if (onSpawned != null)
            {
                onSpawned.Invoke();
            }
            OnSpawned?.Invoke();
        }

        private void OnValidate()
        {
            lookAtSmoothing = Mathf.Clamp(lookAtSmoothing, 0.0f, 1.0f);
            maximalAccelerationForce = Mathf.Max(maximalAccelerationForce, 0.0f);
            maximalSpeed = Mathf.Max(maximalSpeed, 0.0f);
            inertiaDampenerForce = Mathf.Max(inertiaDampenerForce, 0.0f);
            weight = Mathf.Max(weight, float.Epsilon);
            emssSpeed = Mathf.Max(emssSpeed, 0.0f);
            emssDistance = Mathf.Max(emssDistance, 0.0f);
            emssAngle = Mathf.Repeat(emssAngle, 360.0f - float.Epsilon);
            maximalAttachmentCooldownTime = Mathf.Max(maximalAttachmentCooldownTime, 0.0f);
        }

        private void Start()
        {
            if (TryGetComponent(out Rigidbody2D spaceship_rigid_body))
            {
                SpaceshipRigidBody = spaceship_rigid_body;
            }
            else
            {
                Debug.LogError($"Please attach a \"{ nameof(Rigidbody2D) }\" component to this game object.", this);
            }
        }

        private void Update()
        {
            if (SpaceshipRigidBody)
            {
                lookingAt = Vector2.Lerp(lookingAt, lookAt, lookAtSmoothing).normalized;
                SpaceshipRigidBody.SetRotation(Vector2.SignedAngle(Vector2.up, lookingAt));
                Vector2 velocity = SpaceshipRigidBody.velocity;
                if (movement.sqrMagnitude > float.Epsilon)
                {
                    velocity = ClampVelocity(velocity + movement * (maximalAccelerationForce / weight) * Time.deltaTime);
                }
                else if (velocity.sqrMagnitude > float.Epsilon)
                {
                    Vector2 subtract_velocity = velocity.normalized * (inertiaDampenerForce / weight) * Time.deltaTime;
                    velocity = (subtract_velocity.sqrMagnitude < velocity.sqrMagnitude) ? (velocity - subtract_velocity) : Vector2.zero;
                }
                SpaceshipRigidBody.velocity = velocity;
            }
            for (int pinging_index = pinging.Count - 1; pinging_index >= 0; pinging_index--)
            {
                (PingableControllerScript, float) pingable = pinging[pinging_index];
                if (pingable.Item1)
                {
                    float current_time = pingable.Item2 - Time.deltaTime;
                    if (current_time > 0.0f)
                    {
                        pinging[pinging_index] = (pingable.Item1, current_time);
                    }
                    else
                    {
                        pinging.RemoveAt(pinging_index);
                        pingable.Item1.ReceivePing(this);
                    }
                }
                else
                {
                    pinging.RemoveAt(pinging_index);
                }
            }
            if (AttachmentCooldownTime > 0.0f)
            {
                AttachmentCooldownTime = Mathf.Max(AttachmentCooldownTime - Time.deltaTime, 0.0f);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (SpaceshipRigidBody)
            {
                Vector2 velocity_sum = Vector2.zero;
                uint collision_count = 0U;
                for (int contact_point_index = 0; contact_point_index < collision.contactCount; contact_point_index++)
                {
                    ContactPoint2D contact_point = collision.GetContact(contact_point_index);
                    if (contact_point.collider.GetComponentInParent<CollidableControllerScript>() is CollidableControllerScript collidable_controller)
                    {
                        velocity_sum -= Vector2.Reflect(contact_point.relativeVelocity, contact_point.normal) * collidable_controller.Bounciness;
                        ++collision_count;
                        collidable_controller.Collide();
                    }
                    if ((AttachmentCooldownTime <= 0.0f) && !AttachedContainerController && contact_point.collider.GetComponentInParent<ContainerControllerScript>() is ContainerControllerScript container_controller)
                    {
                        container_controller.transform.SetParent(transform, true);
                        AttachedContainerController = container_controller;
                        if (onContainerAttached != null)
                        {
                            onContainerAttached.Invoke();
                        }
                        OnContainerAttached?.Invoke(container_controller);
                        container_controller.InvokeAttachedEvent();
                    }
                }
                if (collision_count > 0U)
                {
                    SpaceshipRigidBody.velocity = ClampVelocity(velocity_sum / collision_count);
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (AttachedContainerController && collider.GetComponentInParent<SpawnPointControllerScript>() is SpawnPointControllerScript spawn_point_controller)
            {
                ContainerControllerScript attached_container_controller = AttachedContainerController;
                DetachContainer();
                spawn_point_controller.CollectContainer(attached_container_controller);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Vector3 position = transform.position;
            Vector3 looking_at = new Vector3(lookingAt.x, lookingAt.y, 0.0f);
            Gizmos.DrawLine(position, position + (looking_at * emssDistance));
            Gizmos.DrawLine(position, position + (Quaternion.AngleAxis(emssAngle * 0.5f, Vector3.forward) * looking_at * emssDistance));
            Gizmos.DrawLine(position, position + (Quaternion.AngleAxis(emssAngle * -0.5f, Vector3.forward) * looking_at * emssDistance));
        }
#endif
    }
}
