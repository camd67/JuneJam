using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player.InputSystem
{
    public class GlobalActionHandler : MonoBehaviour
    {
        private PlayerInputActions playerInput;

        private void Start()
        {
            if (playerInput != null)
            {
                return;
            }

            playerInput = new PlayerInputActions();
            playerInput.GlobalActions.Enable();

            playerInput.GlobalActions.Quit.performed += _ => Application.Quit();

            playerInput.GlobalActions.Restart.performed += _ => SceneManager.LoadScene("Scenes/Gameplay");
        }
    }
}
