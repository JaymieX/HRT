using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCollisionHandleBehaviour : CollisionHandleBehaviour
{
    public override void OnCollisionEnter2DEvent(GameObject sender, Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ObjectPool.Instance.Kill("blood", sender);
        }
    }
}
