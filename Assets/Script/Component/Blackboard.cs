using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard
{
    private Dictionary<string, object> _pool;

    public Blackboard()
    {
        _pool = new Dictionary<string, object>();
    }

    public void Insert<T>(string name, T genericObject)
    {
        _pool[name] = genericObject;
    }

    public T At<T>(string name)
    {
        if (_pool.ContainsKey(name))
        {
            return (T)(_pool[name]);
        }

        Debug.Log("Key" + name + "does not exists");
        return default(T);
    }
}
