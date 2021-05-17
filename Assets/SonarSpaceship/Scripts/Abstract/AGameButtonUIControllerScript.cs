using UnityEngine;
using UnityEngine.UI;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(Button))]
    public abstract class AGameButtonUIControllerScript : MonoBehaviour, IGameButtonUIController
    {
        protected abstract void ClickEvent();

        public Button GameButton { get; private set; }

        protected virtual void Start()
        {
            if (TryGetComponent(out Button game_button))
            {
                GameButton = game_button;
                game_button.onClick.AddListener(ClickEvent);
            }
            else
            {
                Debug.LogError($"Please attach a \"{ nameof(Button) }\" component to this game object.");
            }
        }

        protected virtual void OnDestroy()
        {
            if (GameButton)
            {
                GameButton.onClick.RemoveListener(ClickEvent);
                GameButton = null;
            }
        }
    }
}
