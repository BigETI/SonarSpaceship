using UnityEngine;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class WorldConstraintsControllerScript : MonoBehaviour, IWorldConstraintsController
    {
        private readonly BoxCollider2D[] sideColliders = new BoxCollider2D[4];

        [SerializeField]
        private Vector2 worldSize = Vector2.one * 40.0f;

        private Vector2 lastWorldSize;

        public Vector2 WorldSize
        {
            get => worldSize;
            set
            {
                lastWorldSize = new Vector2(Mathf.Abs(value.x), Mathf.Abs(value.y));
                if (worldSize != lastWorldSize)
                {
                    worldSize = lastWorldSize;
                    UpdateColliders();
                }
            }
        }

        private bool ValidateColliders()
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

        private void UpdateColliders()
        {
            if (ValidateColliders())
            {
                Vector2 position = (worldSize + Vector2.one) * 0.5f;
                Vector2 size = worldSize + (Vector2.one * 2.0f);
                foreach (BoxCollider2D side_collider in sideColliders)
                {
                    if (side_collider)
                    {
                        Destroy(side_collider.gameObject);
                    }
                }
                if (InstantiateGameObjectWithBoxCollider2D("TopWorldBorder", out BoxCollider2D box_collider_2d))
                {
                    box_collider_2d.transform.localPosition = new Vector2(0.0f, position.y);
                    box_collider_2d.size = new Vector2(size.x, 1.0f);
                    sideColliders[0] = box_collider_2d;
                }
                if (InstantiateGameObjectWithBoxCollider2D("BottomWorldBorder", out box_collider_2d))
                {
                    box_collider_2d.transform.localPosition = new Vector2(0.0f, -position.y);
                    box_collider_2d.size = new Vector2(size.x, 1.0f);
                    sideColliders[1] = box_collider_2d;
                }
                if (InstantiateGameObjectWithBoxCollider2D("LeftWorldBorder", out box_collider_2d))
                {
                    box_collider_2d.transform.localPosition = new Vector2(-position.x, 0.0f);
                    box_collider_2d.size = new Vector2(1.0f, size.y);
                    sideColliders[2] = box_collider_2d;
                }
                if (InstantiateGameObjectWithBoxCollider2D("RightWorldBorder", out box_collider_2d))
                {
                    box_collider_2d.transform.localPosition = new Vector2(position.x, 0.0f);
                    box_collider_2d.size = new Vector2(1.0f, size.y);
                    sideColliders[3] = box_collider_2d;
                }
            }
            else
            {
                Debug.LogError($"Please attach a \"{ nameof(PolygonCollider2D) }\" component to this game object.");
            }
        }

        private bool InstantiateGameObjectWithBoxCollider2D(string name, out BoxCollider2D boxCollider2D)
        {
            GameObject game_object = new GameObject(name, typeof(BoxCollider2D));
            game_object.transform.SetParent(transform, false);
            return game_object.TryGetComponent(out boxCollider2D);
        }

        private void Start() => UpdateColliders();

#if UNITY_EDITOR
        private void Update()
        {
            if (lastWorldSize != worldSize)
            {
                lastWorldSize = worldSize;
                UpdateColliders();
            }
        }

        private void OnValidate()
        {
            worldSize = new Vector2(Mathf.Abs(worldSize.x), Mathf.Abs(worldSize.y));
            ValidateColliders();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(worldSize.x, worldSize.y, 1.0f));
        }
#endif
    }
}
