using SonarSpaceship.Controllers;

namespace SonarSpaceship
{
    public interface IRandomSpaceshipTeleporterController : IBehaviour
    {
        public float MinimalCollisionDistance { get; set; }

        WorldConstraintsControllerScript WorldConstraintsController { get; }

        void Teleport();
    }
}
