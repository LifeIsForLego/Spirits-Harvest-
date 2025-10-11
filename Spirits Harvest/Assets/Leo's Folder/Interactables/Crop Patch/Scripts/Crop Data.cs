using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class CropData : ScriptableObject
{
    public TileBase[] tiles;

    public string crops;

    public int value;

    public bool Interactable;

    public bool canPlant;

    public float growthTimer;

    //REMEMBER TO SET ALL VARIABLES WHEN YOU MAKE A NEW OBJECT

    private void Awake()
    {

    }

    //public float TimerCheck()
    //{
    //    return growthTimer;
    //}

    //public void setTimer(float timer)
    //{
    //    growthTimer = timer;
    //}
}
