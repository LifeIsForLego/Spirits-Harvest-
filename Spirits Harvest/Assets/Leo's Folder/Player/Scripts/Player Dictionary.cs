using System.Collections.Generic;
using UnityEngine;

public class PlayerDictionary : MonoBehaviour
{
    public static Dictionary<string,int> HeldItems = new Dictionary<string,int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetHeldItems();
        Debug.Log(HeldItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(string item, int value)
    {
        if(HeldItems.ContainsKey(item))
        {
            HeldItems[item] += value;
        }
        else
        {
            HeldItems[item] = value;
        }

        Debug.Log(item + HeldItems[item]);
    }

    public void ResetHeldItems()
    {
        HeldItems.Clear();
        AddItem("Pumpkin", 0);
        AddItem("Candle", 0);
    }

    public void RemoveItem(string item, int value)
    {
        if(value == 0) //if 0 is passed, removes item completely
        {
            //HeldItems.Remove(item);
            Debug.Log("error, you put a 0 here dummy");
        }
        else
        {
            int newValue = HeldItems[item] - value; //sets a new value which is the currently held value - value to remove

            if(newValue <= 0) //if the new value is equal to or below 0, it removes the item completely
            {
                //HeldItems.Remove(item);
            }
            else
            {
                HeldItems[item] = newValue; //sets the item to the new value
            }
        }
    }

    public int GetItem(string item)
    {
        return HeldItems[item];
    }
}
