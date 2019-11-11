using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDirectMoveInput : InputBehaviour
{
    [SerializeField]
    private Vector3 direction;

    public override Vector3 Input()
    {
        return direction;
    }
}
