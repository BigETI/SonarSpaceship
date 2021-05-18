using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public abstract class ASpaceshipControllerAudioSourceControllerScript : AAudioSourceControllerScript, ISpaceshipControllerAudioSourceController
    {
        public SpaceshipControllerScript SpaceshipController { get; private set; }

        protected override void Start()
        {
            base.Start();
            SpaceshipController = GetComponentInParent<SpaceshipControllerScript>();
            if (!SpaceshipController)
            {
                Debug.LogError($"Make sure that this game object is a child of a game object containing a \"{ nameof(SpaceshipControllerScript) }\" component.", this);
            }
        }
    }
}
