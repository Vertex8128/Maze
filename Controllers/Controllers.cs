using System.Collections.Generic;

public class Controllers : IInitialization, IExecute, ILateExecute, ICleanup
{
    private readonly List<IInitialization> _initializeControllers;
    private readonly List<IExecute> _executeControllers;
    private readonly List<ILateExecute> _lateExecuteControllers;
    private readonly List<ICleanup> _cleanupControllers;

    public Controllers()
    {
        _initializeControllers = new List<IInitialization>();
        _executeControllers = new List<IExecute>();
        _lateExecuteControllers = new List<ILateExecute>();
        _cleanupControllers = new List<ICleanup>();
    }

    public void Add(IController controller)
    {
        if (controller is IInitialization initializeController)
        {
            _initializeControllers.Add(initializeController);
        }

        if (controller is IExecute executeController)
        {
            _executeControllers.Add(executeController);
        }

        if (controller is ILateExecute lateExecuteController)
        {
            _lateExecuteControllers.Add(lateExecuteController);
        }

        if (controller is ICleanup cleanupController)
        {
            _cleanupControllers.Add(cleanupController);
        }
    }

    public void Initialization()
    {
        for (int index = 0; index < _initializeControllers.Count; index++)
        {
            _initializeControllers[index].Initialization();
        }
    }

    public void Execute(float deltaTime)
    {
        for (int index = 0; index < _executeControllers.Count; index++)
        {
            _executeControllers[index].Execute(deltaTime);
        }
    }
    
    public void LateExecute(float deltaTime)
    {
        for (int index = 0; index < _lateExecuteControllers.Count; index++)
        {
            _lateExecuteControllers[index].LateExecute(deltaTime);
        }
    }

    public void Cleanup()
    {
        for (int index = 0; index < _cleanupControllers.Count; index++)
        {
            _cleanupControllers[index].Cleanup();
        }
    }
}