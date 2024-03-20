using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField]
    private Camera camera;

    CommandsExecutor commandsExecutor;

    private void Start() {
        commandsExecutor = new CommandsExecutor();
    }

    private void Update() {
        Lamp raycastLamp;

        if (Input.GetMouseButtonDown(0) && RaycastToObject<Lamp>(out raycastLamp)) {
            commandsExecutor.ExecuteCommand(new PowerCommand(raycastLamp));
        } else if (Input.GetMouseButtonDown(1) && RaycastToObject<Lamp>(out raycastLamp)) {
            commandsExecutor.ExecuteCommand(new ChangeColorCommand(raycastLamp));
        } else if (Input.GetKeyDown(KeyCode.Z)) {
            commandsExecutor.RedoCommand();
        }
    }

    private bool RaycastToObject<ObjClass>(out ObjClass obj) {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f) && raycastHit.transform != null) {
            if (raycastHit.transform.TryGetComponent<ObjClass>(out ObjClass foundObj)) {
                obj = foundObj;
                return true;
            }
        }

        obj = default(ObjClass);
        return false;
    }

}
