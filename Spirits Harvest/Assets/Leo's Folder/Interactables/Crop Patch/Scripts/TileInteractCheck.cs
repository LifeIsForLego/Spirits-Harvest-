using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class TileInteractCheck : MonoBehaviour
{
    GameObject player;
    PlayerInputs inputs;
    PlayerManager manager;

    TileSwapping swap;


    [SerializeField]Tilemap cropMap;

    [SerializeField]List<CropData> Data;

    Dictionary<TileBase, CropData> tileDict;

    [SerializeField]CropData emptyPlot;

    bool canInteract; //overlapping witht the player
    bool Interactable; //is currently able to be interacted with
    bool canPlant;
    float Timer;

    Vector3Int tempPos;

    [SerializeField] bool oneTime; //if true, then destroys itself on pickup
    [SerializeField] string item; //if it has an item attached to it, this is where the name of it is stored
    [SerializeField] int value; //if the player picks it up and obtains a multiple of the item this is how many items it is

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
        player = PlayerInputs.GetInstance().gameObject;
        inputs = player.GetComponent<PlayerInputs>();
        manager = player.GetComponent<PlayerManager>();

        swap = GetComponent<TileSwapping>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.playerMode)
        {
            if (canInteract && inputs.InteractInput && manager.canHarvest)
            {
                manager.InteractionStart(item, value); //for the love of god put "null" and 0 if you want them blank
                if (oneTime)
                {
                    Timer = manager.GetInteractTick();
                    StartCoroutine(DeleteSelf());
                }
            }
            else if (canPlant && inputs.InteractInput && manager.canPlant)
            {
                manager.InteractionStart("null", 0);
                Vector3Int gridpos = cropMap.WorldToCell(player.transform.position);
                swap.AddPumpkin(gridpos);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        
        if (coll.CompareTag("Player"))
        {
            Vector3Int gridpos = cropMap.WorldToCell(player.transform.position);

            TileBase tile = cropMap.GetTile(gridpos);

            if (tile != null)
            {

                bool state = tileDict[tile].Interactable;
                bool plant = tileDict[tile].canPlant;

                //Debug.Log(state);

                canInteract = state;
                canPlant = plant;
                tempPos = gridpos;

                item = tileDict[tile].crops;
                value = tileDict[tile].value;
            }
            else
            {
                canInteract = false;
                canPlant = false;
            }


        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            canInteract = false;
            canPlant = false;
        }
    }

    void DestroySelf()
    {
        //tilemap.SetTile(pos, BlankTile.tiles[0]);
        cropMap.SetTile(tempPos, emptyPlot.tiles[0]);
    }

    IEnumerator DeleteSelf()
    {
        yield return new WaitForSeconds(Timer);
        DestroySelf();
    }
}
