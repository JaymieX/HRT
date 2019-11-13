using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    internal delegate void CollisionEnter2DHandler(GameObject sender, Collision2D col);

    internal event CollisionEnter2DHandler OnCollisionEnter2DEvent;

    private void OnCollisionEnter2D(Collision2D col)
    {
        OnCollisionEnter2DEvent?.Invoke(gameObject, col);
    }

    private void Update()
    {
        if (transform.position.y <= -10f)
        {
            ObjectPool.Instance.Kill("blood", gameObject);
        }
    }
}
