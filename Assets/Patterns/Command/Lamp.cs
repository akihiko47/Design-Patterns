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

    public void SetRandomColor() {
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", randomColor);
    }

}
