using System.Collections.Generic;

public class CommandManager
{
    private readonly Queue<ICommand> _queue = new();
    private bool _isExecuting;

    public void ExecuteCommand(ICommand command)
    {
        _queue.Enqueue(command);

        if (!_isExecuting) StartExecuting();
    }

    private async void StartExecuting()
    {
        _isExecuting = true;

        while (_queue.TryDequeue(out var command)) await command.Execute();

        _isExecuting = false;
    }
}