using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public class RefillStationControllerScript : MonoBehaviour, IRefillStationController
    {
        [SerializeField]
        private float fuelCapacity = 30.0f;

        [SerializeField]
        private float pumpingFuelPerSecond = 10.0f;

        public float FuelCapacity
        {
            get => fuelCapacity;
            set => fuelCapacity = Mathf.Max(value, 0.0f);
        }

        public float PumpingFuelPerSecond
        {
            get => pumpingFuelPerSecond;
            set => pumpingFuelPerSecond = Mathf.Max(value, 0.0f);
        }

        private void OnValidate()
        {
            fuelCapacity = Mathf.Max(fuelCapacity, 0.0f);
            pumpingFuelPerSecond = Mathf.Max(pumpingFuelPerSecond, 0.0f);
        }

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
