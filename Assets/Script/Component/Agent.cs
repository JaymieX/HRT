using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    }

    private void OnEnable()
    {
        _lock = false;
    }

    private void Update()
    {
        if (transform.position.y <= -10f)
        {
            _lock = true;
            ObjectPool.Instance.Kill("blood", gameObject);
        }
    }
}
