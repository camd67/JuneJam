using UnityEngine;

namespace Player
{
    /**
     * Collects and organizes input from the player
     */
    public class InputManager : MonoBehaviour
    {
        [Header("Movement")]
        public Vector2 movementInput;

        public float horizontalInput;
        public float verticalInput;
        public float moveAmount;

        [Header("Camera")]
        public Vector2 cameraInput;

        public float cameraInputX;
        public float cameraInputY;

        [Header("Actions")]
        public bool isSprinting;

        public bool jumpInput;

        private AnimatorManager animatorManager;
        private PlayerInputMaps playerInputMaps;
        private PlayerLocomotion playerLocomotion;

        private void Awake()
        {
            animatorManager = GetComponent<AnimatorManager>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        private void OnEnable()
        {
            playerInputMaps ??= new PlayerInputMaps();

            playerInputMaps.PlayerMovement.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
            playerInputMaps.PlayerMovement.Camera.performed += ctx => cameraInput = ctx.ReadValue<Vector2>();

            playerInputMaps.PlayerActions.Sprint.performed += _ => isSprinting = true;
            playerInputMaps.PlayerActions.Sprint.canceled += _ => isSprinting = false;

            playerInputMaps.PlayerActions.Jump.performed += _ => jumpInput = true;
            playerInputMaps.PlayerActions.Jump.canceled += _ => jumpInput = false;

            playerInputMaps.Enable();
        }

        private void OnDisable()
        {
            playerInputMaps.Disable();
        }

        public void HandleAllInputs()
        {
            HandleMovementInput();
            HandleCameraInput();
            HandleJumpInput();
        }

        private void HandleMovementInput()
        {
            horizontalInput = movementInput.x;
            verticalInput = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            animatorManager.UpdateAnimatorValues(0, moveAmount);
        }

        private void HandleCameraInput()
        {
            cameraInputX = cameraInput.x;
            cameraInputY = cameraInput.y;
        }

        private void HandleJumpInput()
        {
            if (jumpInput)
            {
                jumpInput = false;
                playerLocomotion.HandleJump();
            }
        }
    }
}
