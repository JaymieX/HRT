using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

    public static ObjectPool Instance { get; private set; }

    private void AddObject(string oName)
    {
        ObjectLists o = new ObjectLists();
        foreach (var ol in objects)
        {
            if (ol.name == oName)
            {
                o = ol;
            }
        }

        GameObject spawned = Instantiate(o.prototype, transform.position, Quaternion.identity);
        spawned.SetActive(false);

        _pool[o.name].Enqueue(spawned);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
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

    public GameObject SpawnAt(string oName, Vector3 pos)
    {
        GameObject result = null;

        if (_pool.ContainsKey(oName))
        {
            if (_pool[oName].Count == 0)
            {
                AddObject(oName);
            }

            GameObject obj = _pool[oName].Dequeue();

            if (obj != null)
            {
                obj.transform.position = pos;

                obj.SetActive(true);

                result = obj;
            }
            else
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine("Error while spawning.");
                error.AppendLine("Name: " + oName);
                Debug.Log(error.ToString());
            }
        }

        return result;
    }

    public void Kill(string oName, GameObject o)
    {
        o.SetActive(false);
        o.transform.position = transform.position;

        _pool[oName].Enqueue(o);
    }
}
