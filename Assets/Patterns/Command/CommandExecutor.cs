using System.Collections.Generic;

public class CommandsExecutor {

    Stack<ICommand> commandList;

    public CommandsExecutor() {
        commandList = new Stack<ICommand>();
    }

    public void ExecuteCommand(ICommand command) {
        command.Execute();
        commandList.Push(command);
    }

    public void RedoCommand() {
        if (commandList.Count > 0) {
            ICommand redoCommand = commandList.Pop();
            redoCommand.Redo();
        }
    }
}