using UnityEngine;

public sealed class InputManager : MonoBehaviour
{
    public Vector3 GetMovemnet()
    {

        var xInput = Input.GetAxis(AxisManager.HORIZONTAL);
        var zInput = Input.GetAxis(AxisManager.VERTICAL);
        return new Vector3(xInput, 0, zInput);
    }

    public float GetRotation()
    {
       return Input.GetAxis(AxisManager.MOUSEX);
    }

    public bool GetJump()
    {
        return Input.GetButtonDown(AxisManager.JUMP);
    }
}
