
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float angle;

    [SerializeField]
    private Space relativeTo;

    [SerializeField]
    private Vector3 axis;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis, angle * Time.deltaTime, relativeTo);
    }
}
