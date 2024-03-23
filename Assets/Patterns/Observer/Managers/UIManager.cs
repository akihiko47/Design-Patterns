using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IObserver {

    [SerializeField]
    Subject playerSubject;

    private void OnEnable() {
        playerSubject.AddObserver(this);
    }

    private void OnDisable() {
        playerSubject.RemoveObserver(this);
    }

    public void OnNotify() {
        Debug.Log("Showing jump icon");
    }

}
