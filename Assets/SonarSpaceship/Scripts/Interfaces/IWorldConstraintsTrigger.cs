using UnityEngine;

namespace SonarSpaceship
{
    public interface IWorldConstraintsTrigger : IBehaviour
    {
        Vector2 WorldSize { get; set; }
    }
}
