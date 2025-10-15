using UnityEngine;

public class JackOLantern : MonoBehaviour

    //The Jack O Lantern will take damage when an enemy comes into contact with it
    //It also attacks if an enemy comes in range of it 
    //The attack is a flamethrower, that shoots out in front of it (depending on where it is placed).
    //The attack will need a cooldown or a way to detect if enemies come nearby. Similar to the peashooter in pvz
    //

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] public float lanternHealth = 10.0f;
    [SerializeField] public float lanternDamage = 10.0f;
   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lanternTakeDamage(float damage)
    {
        lanternDamage -= damage;
    }

}
