using UnityEngine;

namespace Player
{
    /**
     * Organizes and orchestrates the player input and locomotion
     */
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        private CameraManager cameraManager;

        [SerializeField]
        private Animator animator;

        public bool isInteracting;

        private InputManager inputManager;
        private PlayerLocomotion playerLocomotion;

        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        private void Update()
        {
            inputManager.HandleAllInputs();
        }

        private void FixedUpdate()
        {
            playerLocomotion.HandleAllMovement();
        }

        private void LateUpdate()
        {
            cameraManager.HandleAllCameraMovement();

            isInteracting = animator.GetBool(AnimatorManager.IsInteractingParam);
            playerLocomotion.isJumping = animator.GetBool(AnimatorManager.IsJumpingParam);
            animator.SetBool(AnimatorManager.IsGroundedParam, playerLocomotion.isGrounded);
        }
    }
}
