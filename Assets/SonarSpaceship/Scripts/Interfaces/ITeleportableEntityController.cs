using UnityEngine;

namespace SonarSpaceship
{
    public interface ITeleportableEntityController : IBehaviour
    {
        Vector2[] Positions { get; set; }

        void Teleport();
    }
}
