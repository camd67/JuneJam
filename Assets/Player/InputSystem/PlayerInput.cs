using UnityEngine;

namespace Player.InputSystem
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        public bool isFiring;

        private PlayerInputActions inputActions;

        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerInputActions();

                inputActions.PlayerActions.Fire.started += _ => isFiring = true;
                inputActions.PlayerActions.Fire.canceled += _ => isFiring = false;
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
    }
}
