using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ObjectLists
{
    public string name;
    public GameObject prototype;
    public ushort count;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<ObjectLists> objects;

    private Dictionary<string, Queue<GameObject>> _pool;

    private static ObjectPool _instance;
    public static ObjectPool Instance => _instance;


    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        _pool = new Dictionary<string, Queue<GameObject>>();

        foreach (var o in objects)
        {
            _pool.Add(o.name, new Queue<GameObject>());
            for (int i = 0; i < o.count; i++)
            {
                GameObject spawned = Instantiate(o.prototype, transform.position, Quaternion.identity);
                spawned.SetActive(false);

                _pool[o.name].Enqueue(spawned);
            }
        }
    }

    public void SpawnAt(string oName, Vector3 pos)
    {
        if (_pool.ContainsKey(oName))
        {
            if (_pool[oName].Count > 0)
            {
                GameObject obj = _pool[oName].Dequeue();
                obj.transform.position = pos;

                obj.SetActive(true);
            }
        }
    }

    public void Kill(string oName, GameObject o)
    {
        o.SetActive(false);
        o.transform.position = transform.position;

        _pool[oName].Enqueue(o);
    }
}
