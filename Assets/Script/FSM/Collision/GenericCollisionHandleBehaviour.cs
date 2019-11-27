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
        switch (col.gameObject.tag) {
            case "Player":
                switch (sender.gameObject.tag) {
                    case "Blood":
                        col.gameObject.transform.root.GetComponent<HealthComponent>().HealHealth(4f);
                        break;
                    case "Tes":
                        col.gameObject.transform.root.GetComponent<HealthComponent>().DamageHealth(2f);
                        break;
                    default:
                        break;
                }
                break;
            case "Shield":
                switch (sender.gameObject.tag) {
                    case "Blood":
                        col.gameObject.transform.root.GetComponent<HealthComponent>().HealHealth(2f);
                        break;
                    default:
                        break;
                }
                break;
            default:
                ObjectPool.Instance.Kill(poolName, sender);
                break;
        }

        ObjectPool.Instance.Kill(poolName, sender);
    }
}
