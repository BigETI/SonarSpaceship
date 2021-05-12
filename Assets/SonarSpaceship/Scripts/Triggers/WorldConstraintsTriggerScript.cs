using UnityEngine;

namespace SonarSpaceship.Triggers
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class WorldConstraintsTriggerScript : MonoBehaviour, IWorldConstraintsTrigger
    {
        [SerializeField]
        private Vector2 worldSize = Vector2.one * 40.0f;

        public Vector2 WorldSize
        {
            get => worldSize;
            set => worldSize = new Vector2(Mathf.Abs(value.x), Mathf.Abs(value.y));
        }

        private bool UpdateColliders()
        {
            bool ret = TryGetComponent(out PolygonCollider2D poygon_collider_2d);
            if (ret)
            {
                Vector2 half = worldSize * 0.5f;
                Vector2 minus_half = worldSize * -0.5f;
                poygon_collider_2d.pathCount = 1;
                poygon_collider_2d.SetPath
                (
                    0,
                    new Vector2[]
                    {
                        new Vector2(minus_half.x, half.y),
                        new Vector2(half.x, half.y),
                        new Vector2(half.x, minus_half.y),
                        new Vector2(minus_half.x, minus_half.y)
                    }
                );
            }
            return ret;
        }

        private bool InstantiateGameObjectWithBoxCollider2D(string name, out BoxCollider2D boxCollider2D)
        {
            GameObject game_object = new GameObject(name, typeof(BoxCollider2D));
            game_object.transform.SetParent(transform, false);
            return game_object.TryGetComponent(out boxCollider2D);
        }

        private void Start()
        {
            if (UpdateColliders())
            {
                Vector2 position = (worldSize + Vector2.one) * 0.5f;
                Vector2 size = worldSize + (Vector2.one * 2.0f);
                BoxCollider2D box_collider_2d;
                if (InstantiateGameObjectWithBoxCollider2D("TopWorldBorder", out box_collider_2d))
                {
                    box_collider_2d.transform.localPosition = new Vector2(0.0f, position.y);
                    box_collider_2d.size = new Vector2(size.x, 1.0f);
                }
                if (InstantiateGameObjectWithBoxCollider2D("BottomWorldBorder", out box_collider_2d))
                {
                    box_collider_2d.transform.localPosition = new Vector2(0.0f, -position.y);
                    box_collider_2d.size = new Vector2(size.x, 1.0f);
                }
                if (InstantiateGameObjectWithBoxCollider2D("LeftWorldBorder", out box_collider_2d))
                {
                    box_collider_2d.transform.localPosition = new Vector2(-position.x, 0.0f);
                    box_collider_2d.size = new Vector2(1.0f, size.y);
                }
                if (InstantiateGameObjectWithBoxCollider2D("RightWorldBorder", out box_collider_2d))
                {
                    box_collider_2d.transform.localPosition = new Vector2(position.x, 0.0f);
                    box_collider_2d.size = new Vector2(1.0f, size.y);
                }
            }
            else
            {
                Debug.LogError($"Please attach a \"{ nameof(PolygonCollider2D) }\" component to this game object.");
            }
            Destroy(this);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            worldSize = new Vector2(Mathf.Abs(worldSize.x), Mathf.Abs(worldSize.y));
            UpdateColliders();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(worldSize.x, worldSize.y, 1.0f));
        }
#endif
    }
}
