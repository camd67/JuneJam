using UnityEngine;

namespace Player
{
    /// <summary>
    ///     Moves the character around the scene.
    /// </summary>
    [RequireComponent(typeof(CharacterController), typeof(InputManager))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float gravity;

        [SerializeField]
        private float walkSpeed;

        [SerializeField]
        private float initialJumpVelocity;

        [SerializeField]
        private float maxJumpHeight;

        [SerializeField]
        private float maxJumpTime;

        [SerializeField]
        private Vector3 currentMoveVec;

        private CharacterController characterController;
        private InputManager inputManager;

        private bool isJumping;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            inputManager = GetComponent<InputManager>();
            inputManager.OnJump += HandleJump;
            SetupJumpVariables();
        }

        private void Update()
        {
            var t = transform;

            if (isJumping && characterController.isGrounded)
            {
                isJumping = false;
            }

            // Input movement
            var moveForward = t.forward * inputManager.movementInput.y;
            var moveRight = t.right * inputManager.movementInput.x;

            var inputMoveVec = (moveForward + moveRight).normalized * (walkSpeed * Time.deltaTime);
            currentMoveVec.x = inputMoveVec.x;
            currentMoveVec.z = inputMoveVec.z;

            // Gravity movement
            currentMoveVec.y += gravity * Time.deltaTime;

            characterController.Move(currentMoveVec);
        }

        private void SetupJumpVariables()
        {
            // this is setting things way too high?
            var timeToApex = maxJumpTime / 2f;
            gravity = -2f * maxJumpHeight / Mathf.Pow(timeToApex, 2f);
            initialJumpVelocity = 2f * maxJumpHeight / timeToApex;
        }

        private void HandleJump()
        {
            // No double jumps
            if (isJumping || !characterController.isGrounded)
            {
                return;
            }

            isJumping = true;
            currentMoveVec.y = initialJumpVelocity;
        }
    }
}
