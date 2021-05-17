using SonarSpaceship.InputActions;
using UnityEngine;

namespace SonarSpaceship.Controllers
{
    [RequireComponent(typeof(SpaceshipControllerScript))]
    public class PlayerControllerScript : MonoBehaviour, IPlayerController
    {
        [SerializeField]
        private float maximalTouchMovementDistance = 5.0f;

        public float MaximalTouchMovementDistance
        {
            get => maximalTouchMovementDistance;
            set => maximalTouchMovementDistance = Mathf.Max(value, 1.0f);
        }

        public bool IsTouchscreenPressing { get; private set; }

        public Vector2 TouchMovement { get; private set; }

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
            GameInputActions.GameActionMap.TouchMove.performed += (context) =>
            {
                if (SpaceshipController && GameCamera)
                {
                    Vector2 mouse_position = context.ReadValue<Vector2>();
                    Vector3 world_position = GameCamera.ScreenToWorldPoint(new Vector3(mouse_position.x, mouse_position.y, 0.0f));
                    Vector3 look_at = (world_position - transform.position) / maximalTouchMovementDistance;
                    TouchMovement = new Vector2(look_at.x, look_at.y);
                    if (IsTouchscreenPressing)
                    {
                        SpaceshipController.Movement = new Vector2(look_at.x, look_at.y);
                    }
                }
            };
            GameInputActions.GameActionMap.ScreenLookAt.performed += (context) =>
            {
                if (SpaceshipController && GameCamera)
                {
                    Vector2 mouse_position = context.ReadValue<Vector2>();
                    Vector3 world_position = GameCamera.ScreenToWorldPoint(new Vector3(mouse_position.x, mouse_position.y, 0.0f));
                    Vector3 look_at = world_position - transform.position;
                    SpaceshipController.LookAt = new Vector2(look_at.x, look_at.y);
                }
            };
            GameInputActions.GameActionMap.TouchPressRelease.performed += (context) =>
            {
                if (SpaceshipController && GameCamera)
                {
                    IsTouchscreenPressing = context.ReadValueAsButton();
                    Debug.Log($"IsTouchscreenPressing: { IsTouchscreenPressing }");
                    SpaceshipController.LookAt = TouchMovement;
                    SpaceshipController.Movement = IsTouchscreenPressing ? TouchMovement : Vector2.zero;
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

#if UNITY_EDITOR
        private void OnValidate() => maximalTouchMovementDistance = Mathf.Max(maximalTouchMovementDistance, 1.0f);
#endif
    }
}
