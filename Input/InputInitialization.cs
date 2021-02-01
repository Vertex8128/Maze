public class InputInitialization : IInitialization
{
    private IUserInput _pcInput;

    public InputInitialization()
    {
        _pcInput = new PCInput();
    }
    public void Initialization()
    {
    }

    public IUserInput GetInput()
    {
        return _pcInput;
    }
}
