public class InputController : IExecute
{
    private readonly IUserInput _pcInput;

    public InputController(IUserInput pcInput)
    {
        _pcInput = pcInput;
    }
    
    public void Execute(float deltaTime)
    {
        _pcInput.GetHorizontalAxis();
        _pcInput.GetVerticalAxis();
        _pcInput.GetRotation();
        _pcInput.GetJump();
    }
}
