using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class CropData : ScriptableObject
{
    public TileBase[] tiles;

    public string crops;

    private void Awake()
    {
        Debug.Log("Pumpkin can start growing");
    }
}
