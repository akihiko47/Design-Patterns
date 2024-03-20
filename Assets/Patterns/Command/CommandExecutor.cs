using System.Collections.Generic;

public class CommandsExecutor {

    private Stack<ICommand> _commandsStack;

    public CommandsExecutor() {
        _commandsStack = new Stack<ICommand>();
    }

    public void ExecuteCommand(ICommand command) {
        command.Execute();
        _commandsStack.Push(command);
    }

    public void RedoCommand() {
        if (_commandsStack.Count > 0) {
            ICommand redoCommand = _commandsStack.Pop();
            redoCommand.Redo();
        }
    }
}