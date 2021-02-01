using System;

public interface IUserInput
{
    event Action<float> OnVerticalAxis;
    event Action<float> OnHorizontalAxis;
    event Action<float> OnRotationInput;
    event Action<bool> OnJumpInput;
    void GetVerticalAxis();
    void GetHorizontalAxis();
    void GetRotation();
    void GetJump();

}
