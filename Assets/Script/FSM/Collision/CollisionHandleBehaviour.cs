using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionHandleBehaviour : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        animator.GetComponent<Agent>().OnCollisionEnter2DEvent += OnCollisionEnter2DEvent;
    }

    public abstract void OnCollisionEnter2DEvent(GameObject sender, Collision2D col);

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        animator.GetComponent<Agent>().OnCollisionEnter2DEvent -= OnCollisionEnter2DEvent;
    }
}
