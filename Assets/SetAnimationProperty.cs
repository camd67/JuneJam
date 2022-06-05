using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SetAnimationProperty : StateMachineBehaviour
{
    [SerializeField]
    private BoolPropertySetData[] animationResets;

    private List<BoolPropertySet> enterProperties;
    private List<BoolPropertySet> exitProperties;

    private void Awake()
    {
        enterProperties = new List<BoolPropertySet>();
        exitProperties = new List<BoolPropertySet>();

        foreach (var boolProperty in animationResets)
        {
            var convertedProp = new BoolPropertySet(
                Animator.StringToHash(boolProperty.propertyName),
                boolProperty.value
            );

            if (boolProperty.stateFlags.HasFlag(StateFlag.Enter))
            {
                enterProperties.Add(convertedProp);
            }

            if (boolProperty.stateFlags.HasFlag(StateFlag.Exit))
            {
                exitProperties.Add(convertedProp);
            }
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (var enterProperty in enterProperties) animator.SetBool(enterProperty.propertyKey, enterProperty.value);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        foreach (var enterProperty in exitProperties) animator.SetBool(enterProperty.propertyKey, enterProperty.value);
    }

    [Serializable]
    private struct BoolPropertySetData
    {
        public string propertyName;
        public bool value;
        public StateFlag stateFlags;

        public BoolPropertySetData(string propertyName, bool value, StateFlag stateFlags)
        {
            this.propertyName = propertyName;
            this.value = value;
            this.stateFlags = stateFlags;
        }
    }

    [Serializable, Flags]
    private enum StateFlag
    {
        Enter = 1 << 0,
        Exit = 1 << 1
    }

    private struct BoolPropertySet
    {
        public readonly int propertyKey;
        public readonly bool value;

        public BoolPropertySet(int propertyKey, bool value)
        {
            this.propertyKey = propertyKey;
            this.value = value;
        }
    }
}
