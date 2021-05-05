using UnityEngine;

namespace SonarSpaceship
{
    public static class EntityGizmos
    {
        public static void DrawArrow(Vector3 position, float scale)
        {
            Gizmos.DrawLine(position + (Vector3.up * scale * -0.375f), position + (Vector3.up * scale * 0.375f));
            Gizmos.DrawLine(position + (Vector3.up * scale * 0.375f), position + (Vector3.left * scale * 0.25f));
            Gizmos.DrawLine(position + (Vector3.up * scale * 0.375f), position + (Vector3.right * scale * 0.25f));
        }
    }
}
