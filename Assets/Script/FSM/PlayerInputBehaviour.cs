using UnityEngine;

public class PlayerInputBehaviour : InputBehaviour
{
    [SerializeField]
    private string horizontalAxis;
    [SerializeField]
    private string verticalAxis;

    public override Vector3 Input()
    {
        float hor = UnityEngine.Input.GetAxis(horizontalAxis);
        float ver = UnityEngine.Input.GetAxis(verticalAxis);

        return new Vector3(hor, ver, 0f).normalized;
    }
}
