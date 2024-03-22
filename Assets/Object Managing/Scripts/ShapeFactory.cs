using UnityEngine;

[CreateAssetMenu]
public class ShapeFactory : ScriptableObject {

    [SerializeField]
    private Shape[] prefabs;

    public Shape GetShape(int index) {
        return Instantiate(prefabs[index]);
    }

    public Shape GetRandomShape() {
        return Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
    }
    
}
