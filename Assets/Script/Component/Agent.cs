using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField]
    private string despawnPartical;

    internal delegate void CollisionEnter2DHandler(GameObject sender, Collision2D col);

    internal event CollisionEnter2DHandler OnCollisionEnter2DEvent;

    private bool _lock = true;

    private void OnCollisionEnter2D(Collision2D col)
    {
        OnCollisionEnter2DEvent?.Invoke(gameObject, col);
    }

    void OnDisable()
    {
        if (!_lock)
        {
            ObjectPool.Instance.SpawnAt(despawnPartical, transform.position);
        }

        _lock = false;
    }

    private void Update()
    {
        if (transform.position.y <= -10f)
        {
            ObjectPool.Instance.Kill("blood", gameObject);
        }
    }
}
