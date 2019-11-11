using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMovementBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private float Speed;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InputBehaviour input = animator.GetBehaviour<InputBehaviour>();
        Vector3 position = input.Input();

        animator.gameObject.GetComponent<Rigidbody2D>().AddForce(Speed * Time.deltaTime * position);
    }
}
