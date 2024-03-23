using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Subject {

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Notify();
        }
    }

}
