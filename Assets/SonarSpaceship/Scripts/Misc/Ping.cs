using SonarSpaceship.Controllers;
using System;
using UnityEngine;

namespace SonarSpaceship
{
    internal class Ping : IPing
    {
        public PingableControllerScript PingableController { get; }

        public SpaceshipControllerScript IssuingSpaceshipController { get; }

        public Vector2 StartPosition { get; }

        public Vector2 Direction { get; }

        public float Speed { get; }

        public float MaximalDistance { get; }

        public float Angle { get; }

        public float TraveledDistance { get; private set; }

        public Vector2 LastPingableControllerPosition { get; private set; }

        public Ping(PingableControllerScript pingableController, SpaceshipControllerScript issuingSpaceshipController, Vector2 startPosition, Vector2 direction, float speed, float maximalDistance, float angle)
        {
            if (!pingableController)
            {
                throw new ArgumentNullException(nameof(pingableController));
            }
            if (!issuingSpaceshipController)
            {
                throw new ArgumentNullException(nameof(issuingSpaceshipController));
            }
            if (speed <= float.Epsilon)
            {
                throw new ArgumentException("Speed must be a non-zero positive number.", nameof(angle));
            }
            if (maximalDistance <= float.Epsilon)
            {
                throw new ArgumentException("Maximal distance must be a non-zero positive number.", nameof(maximalDistance));
            }
            if (angle <= float.Epsilon)
            {
                throw new ArgumentException("Angle must be a non-zero positive number.", nameof(angle));
            }
            PingableController = pingableController;
            IssuingSpaceshipController = issuingSpaceshipController;
            StartPosition = startPosition;
            Direction = direction;
            Speed = speed;
            MaximalDistance = maximalDistance;
            Angle = angle;
            Vector3 last_position = pingableController.transform.position;
            LastPingableControllerPosition = new Vector2(last_position.x, last_position.y);
        }

        public EPingResult ProcessPing(float deltaTime)
        {
            if (deltaTime < 0.0f)
            {
                throw new ArgumentException("Delta time can't be negative.", nameof(deltaTime));
            }
            EPingResult ret = EPingResult.Miss;
            if (PingableController && IssuingSpaceshipController)
            {
                Vector3 world_position = PingableController.transform.position;
                Vector2 position = new Vector2(world_position.x, world_position.y);
                if (TraveledDistance < MaximalDistance)
                {
                    Vector2 last_delta = LastPingableControllerPosition - StartPosition;
                    Vector2 delta = position - StartPosition;
                    float last_distance = last_delta.magnitude;
                    float distance = delta.magnitude;
                    float half_angle = Angle * 0.5f;
                    bool last_is_in_sight = (last_distance <= float.Epsilon) || (Vector2.Angle(Direction, last_delta / last_distance) <= half_angle);
                    bool is_in_sight = (distance <= float.Epsilon) || (Vector2.Angle(Direction, delta / distance) <= half_angle);
                    float last_traveled_distance = TraveledDistance;
                    ret = EPingResult.IsProcessing;
                    TraveledDistance = Mathf.Min(last_traveled_distance + (deltaTime * Speed), MaximalDistance);
                    if (last_is_in_sight && is_in_sight)
                    {
                        if (((last_distance <= last_traveled_distance) && (distance >= TraveledDistance)) || ((last_distance >= last_traveled_distance) && (distance <= TraveledDistance)))
                        {
                            PingableController.ReceivePing(IssuingSpaceshipController);
                            ret = EPingResult.Hit;
                        }
                    }
                }
                LastPingableControllerPosition = position;
            }
            return ret;
        }
    }
}
