using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public class RefillStationControllerScript : MonoBehaviour, IRefillStationController
    {
        // TODO: Implement refill station controller script class

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Matrix4x4 old_matrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            EntityGizmos.DrawArrow(Vector3.zero, 1.0f);
            Gizmos.matrix = old_matrix;
        }
#endif
    }
}
