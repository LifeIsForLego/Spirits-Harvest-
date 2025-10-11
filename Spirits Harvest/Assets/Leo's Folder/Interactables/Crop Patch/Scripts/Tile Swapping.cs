using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwapping : MonoBehaviour
{
    [SerializeField] Tilemap cropMap;

    [SerializeField] List<CropData> Data; //this contains every single scriptable crop object

    Dictionary<TileBase, CropData> tileDict; //dictionary to check the tile data

    [SerializeField]CropData Empty; //reference to empty, not really needed?

    [SerializeField]List<CropData> PumpkinStages;//stages 0, 1, 2, 3, 4 //all stages for pumpkin, make a new dict for a new crop

    List<Vector3Int> pumpkinGridPos = new List<Vector3Int>(); //stores grid pos for use on dictionary //stores gridpos for pumpkin dict so make a new one for a new crop

    public Dictionary<Vector3Int,int> PumpkinDict = new Dictionary<Vector3Int,int>(); //holds info on position and stage of crop tiles (specifically pumpkin) //new dict for new crop

    public Dictionary<Vector3Int, float> GrowthTimerDict = new Dictionary<Vector3Int, float>(); //new dict for new crop


    private void Awake()
    {
        tileDict = new Dictionary<TileBase, CropData>();

        foreach (var cropData in Data)
        {
            foreach (var tile in cropData.tiles)
            {
                tileDict.Add(tile, cropData);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PumpkinGrowth();
    }

    void PumpkinGrowth() //duplicate code and change all pumpkin reference to the new crop when adding a new crop
    {
        for (int i = 0; i < pumpkinGridPos.Count; i++)
        {
            Vector3Int gridPos = pumpkinGridPos[i];

            TileBase tile = cropMap.GetTile(gridPos);

            float growthTimer = GrowthTimerDict[gridPos];

            if (growthTimer <= 0)
            {
                //nextStage(gridPos);

                int temp = PumpkinDict[gridPos];

                temp++;

                PumpkinDict[gridPos] = temp;
                cropMap.SetTile(gridPos, PumpkinStages[temp].tiles[0]);
                tile = cropMap.GetTile(gridPos);

                GrowthTimerDict[gridPos] = tileDict[tile].growthTimer;

                if (temp >= PumpkinStages.Count - 1)
                {
                    RemovePumpkin(gridPos);
                    cropMap.SetTile(gridPos, PumpkinStages[temp].tiles[0]);
                    tile = cropMap.GetTile(gridPos);

                    GrowthTimerDict[gridPos] = tileDict[tile].growthTimer;
                    temp = 0;
                }

            }
            else
            {
                growthTimer -= Time.deltaTime;
                GrowthTimerDict[gridPos] = growthTimer;
            }
        }
    }

    public void AddPumpkin(Vector3Int gridPos) //duplicate code and change all pumpkin reference to the new crop when adding a new crop
    {
        if (PumpkinDict.ContainsKey(gridPos))
        {

        }
        else
        {
            PumpkinDict[gridPos] = 0;
            TileBase tile = cropMap.GetTile(gridPos);
            cropMap.SetTile(gridPos, PumpkinStages[0].tiles[0]);
            tile = cropMap.GetTile(gridPos);
            GrowthTimerDict[gridPos] = tileDict[tile].growthTimer;
            pumpkinGridPos.Add(gridPos);
            
        }
    }

    public void RemovePumpkin(Vector3Int gridPos) //duplicate code and change all pumpkin reference to the new crop when adding a new crop
    {
        PumpkinDict.Remove(gridPos);
        GrowthTimerDict.Remove(gridPos);
        pumpkinGridPos.Remove(gridPos);
    }

    public void nextStage(Vector3Int gridPos) //duplicate code and change all pumpkin reference to the new crop when adding a new crop
    {
        int temp = PumpkinDict[gridPos];

        temp++;

        PumpkinDict[gridPos] = temp;

        if(temp >= PumpkinStages.Count)
        {
            RemovePumpkin(gridPos);
            cropMap.SetTile(gridPos, PumpkinStages[temp].tiles[0]);

            TileBase tile = cropMap.GetTile(gridPos);
            GrowthTimerDict[gridPos] = tileDict[tile].growthTimer;
        }
    }

    //private void OnTriggerExit2D(Collider2D coll)
    //{
    //    Vector3Int pos = cropMap.WorldToCell(coll.transform.position);

    //    if (cropMap.GetTile(pos) == Empty.tiles[0])
    //    {
    //        if (coll.CompareTag("PumpkinSeed"))
    //        {
    //            if (cropMap.GetTile(pos) != null)
    //            {
    //                cropMap.SetTile(pos, Pumpkin.tiles[0]);
    //            }
    //        }
    //    }
    //}
}
