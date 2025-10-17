using System.Collections;
using UnityEngine;

public class JackOLantern : MonoBehaviour

    //The Jack O Lantern will take damage when an enemy comes into contact with it
    //It also attacks if an enemy comes in range of it 
    //The attack is a flamethrower, that shoots out in front of it (depending on where it is placed).
    //Will need to have code to detect the nearest waypoint and if the enemy goes onto it 
    //The attack will need a cooldown. Similar to the peashooter in pvz
    //

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] public float lanternHealth = 10.0f;
    [SerializeField] public float lanternDamage = 10.0f;
    [SerializeField] public float lanternCoolDown = 1.0f;

    //erializeField] public GameObject areaOfEffect;
    [SerializeField] public GameObject projectile;
    [SerializeField] public GameObject pumpkin;

    //public Transform projectile;

    [SerializeField] protected Transform nearestPoint;
   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //detectNearestEnemy();
    }

    public void lanternTakeDamage(float damage)
    {
        lanternDamage -= damage;
    }

    public void lanternDoDamage()
    {
        Instantiate(projectile, pumpkin.transform.position, Quaternion.identity);
        

    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy Detected");
            lanternDoDamage();

            //Destroy(gameObject,1);
        }
    }
}
