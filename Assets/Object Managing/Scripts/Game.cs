using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField]
    private Transform prefab;

    [SerializeField]
    private KeyCode spawnKey = KeyCode.C;

    [SerializeField]
    private KeyCode newGameKey = KeyCode.N;

    [SerializeField]
    private KeyCode saveKey = KeyCode.S;

    [SerializeField]
    private KeyCode loadKey = KeyCode.L;

    string savePath;

    List<Transform> objects;

    private void Awake() {
        objects = new List<Transform>();
        savePath = Path.Combine(Application.persistentDataPath, "saveFile");
        Debug.Log(savePath);
    }

    private void Update() {
        if (Input.GetKeyDown(spawnKey)) {
            CreateObject();
        } else if (Input.GetKeyDown(newGameKey)) {
            NewGame();
        } else if (Input.GetKeyDown(saveKey)) {
            Save();
        } else if (Input.GetKeyDown(loadKey)) {
            Load();
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

    private void Save() {
        using (
            BinaryWriter writer = new BinaryWriter(File.Open(savePath, FileMode.Create))
        ) {
            writer.Write(objects.Count);
            for (int i = 0; i < objects.Count; i++) {
                Transform t = objects[i];
                writer.Write(t.localPosition.x);
                writer.Write(t.localPosition.y);
                writer.Write(t.localPosition.z);
            }
        }
    }

    private void Load() {

        NewGame();

        using (
            BinaryReader reader = new BinaryReader(File.Open(savePath, FileMode.Open))
        ) {
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++) {
                Vector3 pos;
                pos.x = reader.ReadSingle();
                pos.y = reader.ReadSingle();
                pos.z = reader.ReadSingle();
                Transform createdObject = Instantiate(prefab);
                createdObject.localPosition = pos;
                objects.Add(createdObject);
            }
        }
    }

}
