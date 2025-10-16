using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //[SerializeField] public GameObject projectile;
    [SerializeField] public Rigidbody2D body;
    //[SerializeField] public float projectileSpeed = 1.0f;
    void Start()
    { 
        body = GetComponent<Rigidbody2D>();
        Destroy(body, 3);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void projectileAttack(float damage,float direction)
    {
        //gameObject.SetActive(true);
        body.linearVelocity = (transform.up * damage) * direction; 


    }    
}
