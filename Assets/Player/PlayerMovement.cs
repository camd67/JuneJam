using UnityEngine;

namespace Player
{
    /// <summary>
    ///     Moves the character around the scene.
    /// </summary>
    [RequireComponent(typeof(CharacterController), typeof(InputManager))]
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController characterController;
        private InputManager inputManager;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
        }
    }
}
