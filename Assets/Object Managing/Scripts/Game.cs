using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game : SaveableObject {

    [SerializeField]
    private ShapeFactory shapeFactory;

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

    List<Shape> shapes;

    private void Awake() {
        shapes = new List<Shape>();
    }

    private void Update() {
        if (Input.GetKeyDown(spawnKey)) {
            CreateShape();
        } else if (Input.GetKeyDown(newGameKey)) {
            NewGame();
        } else if (Input.GetKeyDown(saveKey)) {
            gameStorage.Save(this);
        } else if (Input.GetKeyDown(loadKey)) {
            NewGame();
            gameStorage.Load(this);
        }
    }

    private void CreateShape() {
        Shape instance = shapeFactory.GetRandomShape();
        Transform t = instance.transform;
        t.localPosition = UnityEngine.Random.insideUnitSphere * 5f;
        t.localRotation = UnityEngine.Random.rotation;
        t.localScale = Vector3.one * UnityEngine.Random.Range(0.1f, 1f);
        shapes.Add(instance);
    }

    private void NewGame() {
        for (int i = 0; i < shapes.Count; i++) {
            Destroy(shapes[i].gameObject);
        }
        shapes.Clear();
    }

    public override void Save(GameDataWriter writer) {
        writer.Write(shapes.Count);
        for (int i = 0; i < shapes.Count; i++) {
            shapes[i].Save(writer);
        }
    }

    public override void Load(GameDataReader reader) {
        int count = reader.ReadInt();
        for (int i = 0; i < count; i++) {
            Shape instance = shapeFactory.GetShape(0);
            instance.Load(reader);
            shapes.Add(instance);
        }
    }
}
