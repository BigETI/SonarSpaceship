namespace SonarSpaceship.Controllers
{
    public class PingGameButtonUIControllerScript : AGameButtonUIControllerScript, IPingGameButtonUIController
    {
        protected override void ClickEvent()
        {
            foreach (SpaceshipControllerScript spaceship_controller in SpaceshipControllerScript.EnabledControllers)
            {
                spaceship_controller.Ping();
            }
        }
    }
}
