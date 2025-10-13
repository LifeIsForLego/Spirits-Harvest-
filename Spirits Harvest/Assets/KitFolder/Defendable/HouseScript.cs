using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // The House will need the following things:
    // A health (I've set it to 100 for now)
    // Damage House will need to take in a parameter that will represent the damage that an enemy does to it. That then depeletes the House
    // Optional: If the house can restore health, it could be done between waves or by upgrades. A seperate method, RestoreHouse, will be made for this
    // For now, inputs from the keyboard will be used to represent the damage
    public float houseHealth = 100f;

    public float enemyDamage = 10f;

    public float healHouse = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DamageHouse(enemyDamage);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestoreHouse(healHouse);
        }

        if (houseHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DamageHouse(float damage)
    {
        houseHealth -= damage;
        Debug.Log("The House has taken of damage");
    }

    public void RestoreHouse (float healing)
    {
        if (houseHealth >= 100f)
        {
            Debug.Log("House cannot be healed anymore");
        }

        else if (houseHealth <= 0)
        {
            Debug.Log("House destroyed");
        }

        else
        {
            houseHealth += healing;
        }
    }
}
