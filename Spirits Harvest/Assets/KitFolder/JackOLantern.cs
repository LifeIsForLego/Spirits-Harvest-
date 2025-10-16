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

    [SerializeField] public GameObject projectile;
    [SerializeField] public GameObject Projectile_;

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
        Instantiate(projectile, Projectile_.transform.position, Projectile_.transform.rotation);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy Detected");
            lanternDoDamage();
        }
    }

    //This doesnt work
    //public void detectNearestEnemy()
    //{
    //    if (nearestPoint)
    //   {
    //       Debug.Log("Enemy Detected");
    //  }

}
