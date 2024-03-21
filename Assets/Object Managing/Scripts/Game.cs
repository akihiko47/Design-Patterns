using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField]
    private Transform prefab;

    [SerializeField]
    private KeyCode spawnKey = KeyCode.C;

    [SerializeField]
    private KeyCode newGameKey = KeyCode.N;

    List<Transform> objects;

    private void Awake() {
        objects = new List<Transform>();
    }

    private void Update() {
        if (Input.GetKeyDown(spawnKey)) {
            CreateObject();
        } else if (Input.GetKeyDown(newGameKey)) {
            NewGame();
        }
    }

    private void CreateObject() {
        Transform createdObject = Instantiate(prefab);
        createdObject.localPosition = UnityEngine.Random.insideUnitSphere * 5f;
        createdObject.localRotation = UnityEngine.Random.rotation;
        createdObject.localScale = Vector3.one * UnityEngine.Random.Range(0.1f, 1f);
        objects.Add(createdObject);
    }

    private void NewGame() {
        for (int i = 0; i < objects.Count; i++) {
            Destroy(objects[i].gameObject);
        }
        objects.Clear();
    }

}
