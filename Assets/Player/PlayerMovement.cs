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

        private CharacterController characterController;
        private InputManager inputManager;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            var t = transform;

            // Input movement
            var moveForward = t.forward * inputManager.movementInput.y;
            var moveRight = t.right * inputManager.movementInput.x;

            var moveVector = (moveForward + moveRight).normalized * (walkSpeed * Time.deltaTime);

            // Gravity movement
            moveVector.y -= gravity * Time.deltaTime;

            characterController.Move(moveVector);
        }
    }
}
