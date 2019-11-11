using UnityEngine;

public class BlackboardComponent : MonoBehaviour
{
    internal Blackboard BlackboardData;

    // Start is called before the first frame update
    void Start()
    {
        BlackboardData = new Blackboard();
    }
}
