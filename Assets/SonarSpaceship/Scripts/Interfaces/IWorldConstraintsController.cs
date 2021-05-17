using UnityEngine;

namespace SonarSpaceship
{
    public interface IWorldConstraintsController : IBehaviour
    {
        Vector2 WorldSize { get; set; }
    }
}
