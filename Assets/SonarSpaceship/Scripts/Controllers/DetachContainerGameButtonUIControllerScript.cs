namespace SonarSpaceship.Controllers
{
    public class DetachContainerGameButtonUIControllerScript : AGameButtonUIControllerScript, IDetachContainerGameButtonUIController
    {
        public bool IsAContainerAttachedToAnySpaceship
        {
            get
            {
                bool ret = false;
                foreach (SpaceshipControllerScript spaceship_controller in SpaceshipControllerScript.EnabledControllers)
                {
                    if (spaceship_controller.AttachedContainerController)
                    {
                        ret = true;
                        break;
                    }
                }
                return ret;
            }
        }

        protected override void ClickEvent()
        {
            foreach (SpaceshipControllerScript spaceship_controller in SpaceshipControllerScript.EnabledControllers)
            {
                spaceship_controller.DetachContainer();
            }
        }

        private void Update()
        {
            if (GameButton)
            {
                GameButton.interactable = IsAContainerAttachedToAnySpaceship;
            }
        }
    }
}
