using UnityEngine;

namespace Player
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField]
        private Transform playerTransform;

        [SerializeField, Header("CameraSettings")]
        private float cameraLookSpeed;

        [SerializeField]
        private float cameraPivotSpeed;

        [SerializeField]
        private float lookAngle;

        [SerializeField]
        private float pivotAngle;

        [SerializeField]
        private Vector2 minMaxPivotAngle;

        private InputManager inputManager;

        private void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
        }

        public void HandleAllCameraMovement()
        {
            RotateCamera();
            RotatePlayer();
        }

        private void RotateCamera()
        {
            lookAngle += -inputManager.cameraInputY * cameraLookSpeed;
            var lookRotation = new Vector3(lookAngle, 0, 0);
            lookAngle = Mathf.Clamp(lookAngle, minMaxPivotAngle.x, minMaxPivotAngle.y);

            transform.rotation = Quaternion.Euler(lookRotation);
        }

        private void RotatePlayer()
        {
            pivotAngle += inputManager.cameraInputX * cameraPivotSpeed;
            var pivotRotation = new Vector3(0, pivotAngle, 0);

            var targetRotation = Quaternion.Euler(pivotRotation);
            var playerRotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, cameraPivotSpeed * Time.deltaTime);

            playerTransform.rotation = playerRotation;
        }
    }
}
