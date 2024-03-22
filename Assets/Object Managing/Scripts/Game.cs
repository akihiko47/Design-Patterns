using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game : SaveableObject {

    [SerializeField]
    private SaveableObject prefab;

    [SerializeField]
    private GameStorage gameStorage;

    [SerializeField]
    private KeyCode spawnKey = KeyCode.C;

    [SerializeField]
    private KeyCode newGameKey = KeyCode.N;

    [SerializeField]
    private KeyCode saveKey = KeyCode.S;

    [SerializeField]
    private KeyCode loadKey = KeyCode.L;

    List<SaveableObject> objects;

    private void Awake() {
        objects = new List<SaveableObject>();
    }

    private void Update() {
        if (Input.GetKeyDown(spawnKey)) {
            CreateObject();
        } else if (Input.GetKeyDown(newGameKey)) {
            NewGame();
        } else if (Input.GetKeyDown(saveKey)) {
            gameStorage.Save(this);
        } else if (Input.GetKeyDown(loadKey)) {
            NewGame();
            gameStorage.Load(this);
        }
    }

    private void CreateObject() {
        SaveableObject createdObject = Instantiate(prefab);
        Transform t = createdObject.transform;
        t.localPosition = UnityEngine.Random.insideUnitSphere * 5f;
        t.localRotation = UnityEngine.Random.rotation;
        t.localScale = Vector3.one * UnityEngine.Random.Range(0.1f, 1f);
        objects.Add(createdObject);
    }

    private void NewGame() {
        for (int i = 0; i < objects.Count; i++) {
            Destroy(objects[i].gameObject);
        }
        objects.Clear();
    }

    public override void Save(GameDataWriter writer) {
        writer.Write(objects.Count);
        for (int i = 0; i < objects.Count; i++) {
            objects[i].Save(writer);
        }
    }

    public override void Load(GameDataReader reader) {
        int count = reader.ReadInt();
        for (int i = 0; i < count; i++) {
            SaveableObject obj = Instantiate(prefab);
            obj.Load(reader);
            objects.Add(obj);
        }
    }
}
