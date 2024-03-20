using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField]
    private Lamp lamp;

    CommandsExecutor commandsExecutor;

    private void Start() {
        commandsExecutor = new CommandsExecutor();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PowerCommand powerCommand = new PowerCommand(lamp);
            commandsExecutor.ExecuteCommand(powerCommand);
        } else if (Input.GetKeyDown(KeyCode.E)) {
            ChangeColorCommand colorCommand = new ChangeColorCommand(lamp);
            commandsExecutor.ExecuteCommand(colorCommand);
        } else if(Input.GetKeyDown(KeyCode.Z)) {
            commandsExecutor.RedoCommand();
        }
    }

}
