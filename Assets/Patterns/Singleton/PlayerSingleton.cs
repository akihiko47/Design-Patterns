using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour {

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SoundManagerSingleton.Instance.PlaySound();
        }
    }

}
