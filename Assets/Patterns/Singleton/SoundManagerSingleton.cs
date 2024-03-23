using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerSingleton : MonoBehaviour {

    public static SoundManagerSingleton Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void PlaySound() {
        Debug.Log("Playing sound from singleton");
    }
}
