using System.Collections.Generic;
using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public class RandomSpaceshipTeleporterControllerScript : MonoBehaviour, IRandomSpaceshipTeleporterController
    {
        private readonly List<Collider2D> colliders = new List<Collider2D>();

        [SerializeField]
        private float minimalCollisionDistance = 1.0f;

        public float MinimalCollisionDistance
        {
            get => minimalCollisionDistance;
            set => minimalCollisionDistance = Mathf.Max(value, 0.0f);
        }

        public WorldConstraintsControllerScript WorldConstraintsController { get; private set; }

        public void Teleport()
        {
            if (WorldConstraintsController)
            {
                Vector2 world_size = WorldConstraintsController.WorldSize;
                Vector2 area = new Vector2((world_size.x * 0.5f) - minimalCollisionDistance, (world_size.y * 0.5f) - minimalCollisionDistance);
                Collider2D[] colliders = FindObjectsOfType<Collider2D>();
                float minimal_collision_distance_squared = minimalCollisionDistance * minimalCollisionDistance;
                foreach (SpaceshipControllerScript spaceship_controller in SpaceshipControllerScript.EnabledControllers)
                {
                    Vector2 new_position = Vector2.zero;
                    bool is_looking_for_position = true;
                    while (is_looking_for_position)
                    {
                        new_position = new Vector2(Random.Range(-area.x, area.x), Random.Range(-area.y, area.y));
                        foreach (Collider2D collider in colliders)
                        {
                            if (!collider.isTrigger && ((new_position - collider.ClosestPoint(new_position)).sqrMagnitude < minimal_collision_distance_squared))
                            {
                                is_looking_for_position = false;
                                break;
                            }
                        }
                    }
                    spaceship_controller.transform.position = new Vector3(new_position.x, new_position.y, 0.0f);
                }
            }
        }

        private void Start()
        {
            WorldConstraintsController = FindObjectOfType<WorldConstraintsControllerScript>();
            if (!WorldConstraintsController)
            {
                Debug.LogError($"Please add a game object with component \"{ nameof(WorldConstraintsControllerScript) }\" to scenes first.");
            }
        }

#if UNITY_EDITOR
        private void OnValidate() => minimalCollisionDistance = Mathf.Max(minimalCollisionDistance, 0.0f);
#endif
    }
}
