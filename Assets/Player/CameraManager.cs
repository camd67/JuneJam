using UnityEngine;

namespace Player
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField, Header("Refs")]
        private Transform targetTransform;

        [SerializeField]
        private Transform pivotTransform;

        [SerializeField, Header("CameraSettings")]
        private float cameraFollowSpeed;

        [SerializeField]
        private float cameraLookSpeed;

        [SerializeField]
        private float cameraPivotSpeed;

        [SerializeField]
        private float lookAngle;

        [SerializeField]
        private float pivotAngle;

        [SerializeField]
        private Vector2 minMaxPivotAngle;

        private Vector3 cameraFollowVelocity = Vector3.zero;

        private InputManager inputManager;

        private void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
        }

        public void HandleAllCameraMovement()
        {
            FollowTarget();
            RotateCamera();
        }

        private void FollowTarget()
        {
            var targetPosition = Vector3.SmoothDamp(
                transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed
            );
            transform.position = targetPosition;
        }

        private void RotateCamera()
        {
            // Rotate where we're looking
            lookAngle += inputManager.cameraInputX * cameraLookSpeed;
            var lookRotation = Vector3.zero;
            lookRotation.y = lookAngle;
            transform.rotation = Quaternion.Euler(lookRotation);

            // Then rotate our pivot
            pivotAngle -= inputManager.cameraInputY * cameraPivotSpeed;
            pivotAngle = Mathf.Clamp(pivotAngle, minMaxPivotAngle.x, minMaxPivotAngle.y);
            var pivotRotation = Vector3.zero;
            pivotRotation.x = pivotAngle;
            pivotTransform.localRotation = Quaternion.Euler(pivotRotation);
        }
    }
}
