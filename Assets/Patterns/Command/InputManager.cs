using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField]
    private Lamp lamp;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PowerCommand powerCommand = new PowerCommand(lamp);
            powerCommand.execute();
        } else if (Input.GetKeyDown(KeyCode.E)) {
            ChangeColorCommand colorCommand = new ChangeColorCommand(lamp);
            colorCommand.execute();
        }
    }

}
