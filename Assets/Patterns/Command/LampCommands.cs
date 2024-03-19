using UnityEngine;

public class PowerCommand : ICommand {

    GameObject _lamp;
    bool active;

    public PowerCommand(GameObject lamp) {
        _lamp = lamp;
        active = _lamp.GetComponent<MeshRenderer>().material.IsKeywordEnabled("_EMISSION");
    }

    public void execute() {
        if (active) {
            _lamp.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        } else {
            _lamp.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }
    }

}