using UnityEngine;

namespace SonarSpaceship
{
    public interface IEvilEntityController : IControllersController
    {
        bool IsMovingAway { get; set; }

        float MaximalAccelerationForce { get; set; }

        float MaximalSpeed { get; set; }

        float AttackRadius { get; set; }

        float AvoidanceDistance { get; set; }

        Vector2 MovingAtDirection { get; }

        Rigidbody2D EvilEntityRigidBody { get; }
    }
}
