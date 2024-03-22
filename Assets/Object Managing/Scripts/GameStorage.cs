using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameStorage : MonoBehaviour {

    string savePath;

    private void Awake() {
        savePath = Path.Combine(Application.persistentDataPath, "saveFile");
    }

    public void Save(SaveableObject obj) {
        using (
            BinaryWriter writer = new BinaryWriter(File.Open(savePath, FileMode.Create))
        ) {
            obj.Save(new GameDataWriter(writer));
        }
    }

    public void Load(SaveableObject obj) {

        using (
            BinaryReader reader = new BinaryReader(File.Open(savePath, FileMode.Open))
        ) {
            obj.Load(new GameDataReader(reader));
        }
    }

}
