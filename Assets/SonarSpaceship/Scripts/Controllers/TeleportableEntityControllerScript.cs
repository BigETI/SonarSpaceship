using System;
using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public class TeleportableEntityControllerScript : MonoBehaviour, ITeleportableEntityController
    {
        [SerializeField]
        private Vector2[] positions = new Vector2[] { Vector2.zero };

        private uint lastPositionIndex;

        public Vector2[] Positions
        {
            get
            {
                if ((positions == null) || (positions.Length <= 0))
                {
                    positions = new Vector2[] { Vector2.zero };
                }
                return positions;
            }
            set => positions = value ?? throw new ArgumentNullException(nameof(value));
        }

        public void Teleport()
        {
            if ((positions != null) && (positions.Length > 0))
            {
                lastPositionIndex = (lastPositionIndex + 1U) % (uint)positions.Length;
                Vector2 position = positions[lastPositionIndex];
                Vector3 current_position = new Vector3(position.x, position.y, 0.0f);
                for (int index = 0, child_count = transform.childCount; index < child_count; index++)
                {
                    transform.GetChild(index).localPosition = current_position;
                }
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if ((positions == null) || (positions.Length <= 0))
            {
                positions = new Vector2[] { Vector2.zero };
            }
        }

        private void OnDrawGizmos()
        {
            if ((positions != null) && (positions.Length > 0))
            {
                Matrix4x4 old_matrix = Gizmos.matrix;
                Gizmos.matrix = transform.localToWorldMatrix;
                for (int index = 0; index < positions.Length; index++)
                {
                    Vector2 last_position = positions[(index > 0) ? (index - 1) : (positions.Length - 1)];
                    Vector2 position = positions[index];
                    Vector3 current_position = new Vector3(position.x, position.y, 0.0f);
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawLine(new Vector3(last_position.x, last_position.y, 0.0f), current_position);
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawWireSphere(current_position, 0.5f);
                    Vector3 delta = position - last_position;
                    float distance = delta.magnitude;
                    if (distance > float.Epsilon)
                    {
                        Gizmos.color = Color.green;
                        EntityGizmos.DrawArrow(Vector3.Lerp(last_position, position, 0.5f), distance * 0.25f, Vector3.SignedAngle(Vector3.up, delta / distance, Vector3.forward));
                    }
                }
                Gizmos.matrix = old_matrix;
            }
        }
#endif
    }
}
