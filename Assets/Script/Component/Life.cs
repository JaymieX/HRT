using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float time;

    [SerializeField]
    private string poolID;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        yield return new WaitForSeconds(time);

        ObjectPool.Instance.Kill(poolID, gameObject);
    }
}
