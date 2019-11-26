using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCollisionHandleBehaviour : CollisionHandleBehaviour
{
    private string poolName;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        poolName = animator.GetComponent<Agent>().poolName;
    }

    public override void OnCollisionEnter2DEvent(GameObject sender, Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Wall"))
        {
            ObjectPool.Instance.Kill(poolName, sender);
        }
    }
}
