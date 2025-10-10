using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwapping : MonoBehaviour
{
    Tilemap cropMap;

    [SerializeField]CropData Empty;
    [SerializeField]CropData Pumpkin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cropMap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        Vector3Int pos = cropMap.WorldToCell(coll.transform.position);

        if (cropMap.GetTile(pos) == Empty.tiles[0])
        {
            if (coll.CompareTag("PumpkinSeed"))
            {
                if (cropMap.GetTile(pos) != null)
                {
                    cropMap.SetTile(pos, Pumpkin.tiles[0]);
                }
            }
        }
    }
}
