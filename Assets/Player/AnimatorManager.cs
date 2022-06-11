using UnityEngine;

namespace Player
{
    public class AnimatorManager : MonoBehaviour
    {
        public static readonly int IsInteractingParam = Animator.StringToHash("IsInteracting");
        public static readonly int HorizontalParam = Animator.StringToHash("Horizontal");
        public static readonly int VerticalParam = Animator.StringToHash("Vertical");
        public static readonly int IsJumpingParam = Animator.StringToHash("IsJumping");
        public static readonly int IsGroundedParam = Animator.StringToHash("IsGrounded");
        public static readonly int FallingAniKey = Animator.StringToHash("Falling");
        public static readonly int LandingAniKey = Animator.StringToHash("Landing");
        public static readonly int JumpAniKey = Animator.StringToHash("Jumping");

        [SerializeField]
        private Animator animator;


        public void PlayTargetAnimation(int animationKey, bool isInteracting)
        {
            // animator.SetBool(IsInteractingParam, isInteracting);
            // animator.CrossFade(animationKey, 0.2f);
        }

        public void SetBool(int animationKey, bool value)
        {
            // animator.SetBool(animationKey, value);
        }

        public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
        {
            // animator.SetFloat(HorizontalParam, horizontalMovement, 0.1f, Time.deltaTime);
            // animator.SetFloat(VerticalParam, verticalMovement, 0.1f, Time.deltaTime);
        }
    }
}
