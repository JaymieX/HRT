using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : StateMachineBehaviour
{
    [SerializeField] private float waitTime;

    [SerializeField] private string projectileName;

    private float timeLeft;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        timeLeft = waitTime;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        Vector3 targetPos = GlobalManager.Instance.player.transform.position;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = waitTime;

            Vector3 direction = targetPos - animator.transform.position;
            direction.Normalize();

            GameObject obj = ObjectPool.Instance.SpawnAt(projectileName, animator.transform.position);
            obj.GetComponent<Rigidbody2D>().AddForce(direction * 50000f * Time.deltaTime);
        }
    }
}
