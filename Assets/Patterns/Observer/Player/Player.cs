using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Subject {  // manualy creating pattern

    public event Action OnSpaceActionEvent;  // using delegates

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {

            Notify();  // manual version invoke (from Subject)

            OnSpaceActionEvent?.Invoke();  // delegate version invoke

        }
    }

}
