using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameDataReader {

    BinaryReader reader;

    public GameDataReader(BinaryReader _reader) {
        reader = _reader;
    }

    public float ReadFloat() {
        return reader.ReadSingle();
    }

    public int ReadInt() {
        return reader.ReadInt32();
    }

    public Quaternion ReadQuaternion() {
        Quaternion value;
        value.x = reader.ReadSingle();
        value.y = reader.ReadSingle();
        value.z = reader.ReadSingle();
        value.w = reader.ReadSingle();
        return value;
    }

    public Vector3 ReadVector3() {
        Vector3 value;
        value.x = reader.ReadSingle();
        value.y = reader.ReadSingle();
        value.z = reader.ReadSingle();
        return value;
    }
}
