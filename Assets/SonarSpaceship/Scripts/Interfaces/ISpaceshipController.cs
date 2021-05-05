using SonarSpaceship.Controllers;
using System.Collections.Generic;
using UnityEngine;

namespace SonarSpaceship
{
    public interface ISpaceshipController : IBehaviour
    {
        float LookAtSmoothing { get; set; }

        float MaximalAccelerationForce { get; set; }

        float MaximalSpeed { get; set; }

        float InertiaDampenerForce { get; set; }

        float Weight { get; set; }

        float MaximalFuelCapacity { get; set; }

        float EMSSSpeed { get; set; }

        float EMSSDistance { get; set; }

        float EMSSAngle { get; set; }

        float MaximalAttachmentCooldownTime { get; set; }

        Vector2 Movement { get; set; }

        Vector2 LookAt { get; set; }

        float Fuel { get; set; }

        IReadOnlyCollection<RefillStationControllerScript> DockedRefillStationControllerss { get; }

        ContainerControllerScript AttachedContainerController { get; }

        float AttachmentCooldownTime { get; }

        Rigidbody2D SpaceshipRigidBody { get; }

        event SpawnedDelegate OnSpawned;

        event PingedDelegate OnPinged;

        event ContainerAttachedDelegate OnContainerAttached;

        event ContainerDetachedDelegate OnContainerDetached;

        void Ping();

        void DetachContainer();

        void InvokeSpawnedEvent();
    }
}
