using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputBehaviour : StateMachineBehaviour
{
    protected Vector3 ObjectPosition;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        ObjectPosition = animator.transform.position;
    }

    public abstract Vector3 Input();
}
