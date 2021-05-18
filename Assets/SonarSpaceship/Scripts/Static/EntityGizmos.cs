using UnityEngine;

namespace SonarSpaceship
{
    public static class EntityGizmos
    {
        public static void DrawArrow(Vector3 position, float scale) => DrawArrow(position, scale, 0.0f);

        public static void DrawArrow(Vector3 position, float scale, float rotation)
        {
            Vector3 up = Quaternion.AngleAxis(rotation, Vector3.forward) * Vector3.up;
            Gizmos.DrawLine(position + (up * scale * -0.375f), position + (up * scale * 0.375f));
            Gizmos.DrawLine(position + (up * scale * 0.375f), position + (Quaternion.AngleAxis(rotation, Vector3.forward) * Vector3.left * scale * 0.25f));
            Gizmos.DrawLine(position + (up * scale * 0.375f), position + (Quaternion.AngleAxis(rotation, Vector3.forward) * Vector3.right * scale * 0.25f));
        }
    }
}
