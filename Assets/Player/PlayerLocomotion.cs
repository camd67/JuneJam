using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Player
{
    /**
     * Computes player movement
     */
    public class PlayerLocomotion : MonoBehaviour
    {
        private const float FootSphereSize = 0.2f;
        private const float FootSpherecastDistance = 0.1f;

        [SerializeField]
        private Transform cameraTransform;

        [SerializeField]
        private Vector3 moveDirection;

        [SerializeField, Header("Falling")]
        private float inAirTimer;

        [SerializeField]
        private float leapingVelocity;

        [SerializeField]
        private float fallingVelocity;

        [SerializeField]
        public bool isGrounded;

        [SerializeField]
        private LayerMask groundLayer;

        [SerializeField]
        private float footRaycastOffset;

        [SerializeField, Header("Jumping")]
        private float jumpHeight;

        [SerializeField, Max(0), Tooltip("Must be negative to represent a downward force")]
        private float gravityIntensity;

        [SerializeField]
        public bool isJumping;

        [SerializeField, Header("Movement Settings")]
        private float movementSpeed;

        [SerializeField]
        private float sprintingSpeed;

        [SerializeField]
        private float rotationSpeed;

        private AnimatorManager animatorManager;
        private InputManager inputManager;
        private PlayerManager playerManager;
        private Rigidbody playerRigidbody;

        private void Awake()
        {
            animatorManager = GetComponent<AnimatorManager>();
            playerManager = GetComponent<PlayerManager>();
            inputManager = GetComponent<InputManager>();
            playerRigidbody = GetComponent<Rigidbody>();
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            var position = transform.position;
            position.y += footRaycastOffset;
            Gizmos.DrawSphere(position, FootSphereSize);
            position.y -= footRaycastOffset + FootSpherecastDistance;
            Gizmos.DrawSphere(position, FootSphereSize);
        }
#endif

        public void HandleAllMovement()
        {
            HandleFallingAndLanding();

            if (playerManager.isInteracting || !isGrounded)
            {
                return;
            }

            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            if (isJumping)
            {
                return;
            }

            moveDirection = cameraTransform.forward * inputManager.verticalInput;
            moveDirection += cameraTransform.right * inputManager.horizontalInput;
            moveDirection.Normalize();
            // Prevent upward movement
            moveDirection.y = 0;

            // Scale our movement to be how fast we want to be going
            if (inputManager.isSprinting)
            {
                moveDirection *= sprintingSpeed;
            }
            else
            {
                moveDirection *= movementSpeed * inputManager.moveAmount;
            }

            var movementVelocity = moveDirection;
            playerRigidbody.velocity = movementVelocity;
        }

        private void HandleRotation()
        {
            var targetDirection = cameraTransform.forward * inputManager.verticalInput;
            targetDirection += cameraTransform.right * inputManager.horizontalInput;
            targetDirection.Normalize();
            targetDirection.y = 0;

            if (targetDirection == Vector3.zero)
            {
                targetDirection = transform.forward;
            }

            var targetRotation = Quaternion.LookRotation(targetDirection);
            var playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = playerRotation;
        }

        private void HandleFallingAndLanding()
        {
            if (!isGrounded && !isJumping)
            {
                if (!playerManager.isInteracting)
                {
                    animatorManager.PlayTargetAnimation(AnimatorManager.FallingAniKey, true);
                }

                inAirTimer += Time.deltaTime;
                // take a slight "step" off the ledge when falling
                playerRigidbody.AddForce(transform.forward * leapingVelocity);
                // and then fall downwards
                playerRigidbody.AddForce(Vector3.down * fallingVelocity * inAirTimer);
            }

            var spherecastOrigin = transform.position + Vector3.up * footRaycastOffset;

            if (Physics.SphereCast(spherecastOrigin, FootSphereSize, Vector3.down, out var hit, FootSpherecastDistance, groundLayer))
            {
                if (!isGrounded && playerManager.isInteracting)
                {
                    animatorManager.PlayTargetAnimation(AnimatorManager.LandingAniKey, true);
                }

                inAirTimer = 0;
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        public void HandleJump()
        {
            if (!isGrounded)
            {
                return;
            }

            animatorManager.animator.SetBool(AnimatorManager.IsJumpingParam, true);
            animatorManager.PlayTargetAnimation(AnimatorManager.JumpAniKey, false);
            var jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            // Preserve velocity before jump.
            // So if you're running forward, you'll jump forward. If you're standing still you'll jump straight up.
            var playerVelocity = moveDirection;
            playerVelocity.y = jumpingVelocity;
            playerRigidbody.velocity = playerVelocity;
        }
    }
}
