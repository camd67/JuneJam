using UnityEngine;

namespace Player
{
    /// <summary>
    ///     Handles moving the camera.
    ///     Must be attached to the camera component itself.
    /// </summary>
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField, Header("Refs")]
        private Transform playerTransform;

        [SerializeField, Header("Rotation Settings")]
        private float rotationSpeedY;

        [SerializeField]
        private Vector2 minMaxRotationY;

        [SerializeField]
        private float rotationSpeedX;

        [SerializeField, Header("Info")]
        private float rotationY;

        private InputManager inputManager;

        private void Awake()
        {
            inputManager = GetComponentInParent<InputManager>();
        }

        private void Update()
        {
            HandleCameraVerticalRotation();
            HandleCameraHorizontalRotation();
        }

        private void HandleCameraVerticalRotation()
        {
            rotationY += inputManager.cameraInput.y;

            rotationY = Mathf.Clamp(rotationY, minMaxRotationY.x, minMaxRotationY.y);

            var targetRotation = Quaternion.Euler(-rotationY, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeedY * Time.deltaTime);
        }

        /// <summary>
        ///     Rotate the player to the right based on the x of the camera input.
        /// </summary>
        private void HandleCameraHorizontalRotation()
        {
            var rotation = playerTransform.right * (inputManager.cameraInput.x * rotationSpeedX);
            rotation.Normalize();

            if (rotation == Vector3.zero)
            {
                rotation = playerTransform.forward;
            }

            var targetRotation = Quaternion.LookRotation(rotation, Vector3.up);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, rotationSpeedX * Time.deltaTime);
        }
    }
}
