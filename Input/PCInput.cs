using System;
using UnityEngine;

public class PCInput : IUserInput
{
    public event Action<float> OnVerticalAxis = delegate(float f) { };
    public event Action<float> OnHorizontalAxis = delegate(float f) { };
    public event Action<float> OnRotationInput = delegate(float f) { };
    public event Action<bool> OnJumpInput = delegate(bool b) { };

    public void GetVerticalAxis()
    {
        OnVerticalAxis.Invoke(Input.GetAxis(AxisManager.VERTICAL));
    }

    public void GetHorizontalAxis()
    {
        OnHorizontalAxis.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
    }

    public void GetRotation()
    {
        OnRotationInput.Invoke(Input.GetAxis(AxisManager.MOUSEX));
    }

    public void GetJump()
    {
        OnJumpInput.Invoke(Input.GetButtonDown(AxisManager.JUMP));
    }
}
