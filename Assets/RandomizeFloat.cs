using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomizeFloat : StateMachineBehaviour
{
    [SerializeField]
    private string propertyToRandomize;

    [SerializeField, Tooltip("Optional")]
    private Vector2Int minMaxInt;

    [SerializeField, Tooltip("Optional")]
    private Vector2 minMaxFloat;

    /// <summary>
    ///     Animator hash for the property we care about
    /// </summary>
    private int propertyHash;

    /// <summary>
    ///     Lazy-init field for the index of the property in the animation controller
    ///     Does the index ever change...?
    /// </summary>
    private int propertyIndex = -1;

    private void Awake()
    {
        propertyHash = Animator.StringToHash(propertyToRandomize);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (propertyIndex == -1)
        {
            for (var i = 0; i < animator.parameters.Length; i++)
            {
                if (animator.parameters[i].nameHash == propertyHash)
                {
                    propertyIndex = i;
                }
            }
        }

        switch (animator.GetParameter(propertyIndex).type)
        {
            case AnimatorControllerParameterType.Float:
                animator.SetFloat(propertyHash, Random.Range(minMaxFloat.x, minMaxFloat.y));
                break;
            case AnimatorControllerParameterType.Int:
                animator.SetInteger(propertyHash, Random.Range(minMaxInt.x, minMaxInt.y));
                break;
            case AnimatorControllerParameterType.Bool:
                animator.SetBool(propertyHash, Random.value > 0.5f);
                break;
            case AnimatorControllerParameterType.Trigger:
                throw new Exception("Unable to randomize trigger property");
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
