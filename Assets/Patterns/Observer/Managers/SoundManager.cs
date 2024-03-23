using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour, IObserver {

    [SerializeField]
    Player player;

    private void OnEnable() {
        player.OnSpaceActionEvent += OnNotify;
    }

    private void OnDisable() {
        player.OnSpaceActionEvent -= OnNotify;
    }

    public void OnNotify() {
        Debug.Log("Playing jump sound (delegates version)");
    }

}
