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
        }
    }
}
