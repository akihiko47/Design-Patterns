using UnityEngine;

public class Lamp : MonoBehaviour{

    bool active = false;

    public void SetPower() {
        if (active) {
            GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            active = false;
        } else {
            GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            active = true;
        }
    }

    public void SetColor(Color color) {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
    }

    public Color GetColor() {
        return GetComponent<Renderer>().material.GetColor("_EmissionColor");
    }

}
