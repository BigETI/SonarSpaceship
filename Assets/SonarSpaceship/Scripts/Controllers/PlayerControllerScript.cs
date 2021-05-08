using SonarSpaceship.InputActions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(SpaceshipControllerScript))]
    public class PlayerControllerScript : MonoBehaviour, IPlayerController
    {
        public SpaceshipControllerScript SpaceshipController { get; private set; }

        public GameInputActions GameInputActions { get; private set; }

        public Camera GameCamera { get; private set; }

        private void Awake()
        {
            GameInputActions = new GameInputActions();
            GameInputActions.GameActionMap.DetachContainer.performed += (context) =>
            {
                if (SpaceshipController)
                {
                    SpaceshipController.DetachContainer();
                }
            };
            GameInputActions.GameActionMap.LookAt.performed += (context) =>
            {
                if (SpaceshipController)
                {
                    SpaceshipController.LookAt = context.ReadValue<Vector2>();
                }
            };
            GameInputActions.GameActionMap.MouseLookAt.performed += (context) =>
            {
                if (SpaceshipController && GameCamera)
                {
                    Mouse current_mouse = Mouse.current;
                    if (current_mouse != null)
                    {
                        Vector2 mouse_position = current_mouse.position.ReadValue();
                        Vector3 world_position = GameCamera.ScreenToWorldPoint(new Vector3(mouse_position.x, mouse_position.y, 0.0f));
                        Vector3 look_at = world_position - transform.position;
                        SpaceshipController.LookAt = new Vector2(look_at.x, look_at.y);
                    }
                }
            };
            GameInputActions.GameActionMap.Move.performed += (context) =>
            {
                if (SpaceshipController)
                {
                    SpaceshipController.Movement = context.ReadValue<Vector2>();
                }
            };
            GameInputActions.GameActionMap.Move.canceled += (context) =>
            {
                if (SpaceshipController)
                {
                    SpaceshipController.Movement = Vector2.zero;
                }
            };
            GameInputActions.GameActionMap.Ping.performed += (context) =>
            {
                if (SpaceshipController)
                {
                    SpaceshipController.Ping();
                }
            };
        }

        private void OnDestroy()
        {
            GameInputActions?.Dispose();
            GameInputActions = null;
        }

        private void OnEnable() => GameInputActions?.Enable();

        private void OnDisable() => GameInputActions?.Disable();

        private void Start()
        {
            if (TryGetComponent(out SpaceshipControllerScript spaceship_controller))
            {
                SpaceshipController = spaceship_controller;
            }
            else
            {
                Debug.LogError($"Please attach a \"{ nameof(SpaceshipControllerScript) }\" component to this game object.", this);
            }
            GameCamera = FindObjectOfType<Camera>(true);
        }
    }
}
