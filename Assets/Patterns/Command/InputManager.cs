using UnityEngine;

public class InputManager : MonoBehaviour {

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PowerCommand powerCommand = new PowerCommand(gameObject);
            powerCommand.execute();
        }
    }

}
