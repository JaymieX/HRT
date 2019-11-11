using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct SpawnObjectList
{
    public string name;
    public float minX, maxX, minY, maxY;
    public float interval;
}

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<SpawnObjectList> objects;

    // Update is called once per frame
    private void Start()
    {
        foreach (var o in objects)
        {
            StartCoroutine(Spawn(o));
        }
    }

    private IEnumerator Spawn(SpawnObjectList o)
    {
        while (true)
        {
            yield return new WaitForSeconds(o.interval);

            ObjectPool.Instance.SpawnAt
                (o.name, new Vector3(Random.Range(o.minX, o.maxX), Random.Range(o.minY, o.maxY), 0f));
        }
    }
}