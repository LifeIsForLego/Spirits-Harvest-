using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class CropData : ScriptableObject
{
    public TileBase[] tiles;

    public string crops;

    public int value;

    public bool Interactable;

    private void Awake()
    {

    }
}
