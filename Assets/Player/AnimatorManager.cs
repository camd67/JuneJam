using UnityEngine;

namespace Player
{
    public class AnimatorManager : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        private int horizontalAniKey;
        private int verticalAniKey;

        private void Awake()
        {
            horizontalAniKey = Animator.StringToHash("Horizontal");
            verticalAniKey = Animator.StringToHash("Vertical");
        }

        public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
        {
            animator.SetFloat(horizontalAniKey, horizontalMovement, 0.1f, Time.deltaTime);
            animator.SetFloat(verticalAniKey, verticalMovement, 0.1f, Time.deltaTime);
        }
    }
}
