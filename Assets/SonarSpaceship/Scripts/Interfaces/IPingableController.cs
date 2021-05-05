using SonarSpaceship.Controllers;

namespace SonarSpaceship
{
    public interface IPingableController : IBehaviour
    {
        event PingReceivedDelegate OnPingReceived;

        void ReceivePing(SpaceshipControllerScript spaceshipController);
    }
}
