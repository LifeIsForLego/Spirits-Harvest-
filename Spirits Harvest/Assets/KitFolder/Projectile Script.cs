
using System.Collections;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //[SerializeField] public GameObject projectile;
    [SerializeField] public Rigidbody2D body;
    [SerializeField] public float projectileSpeed = 1.0f;

    [SerializeField] public GameObject projectile;
    [SerializeField] public GameObject pumpkin;
    void Start()
    { 
        body = GetComponent<Rigidbody2D>();
        //Destroy(body, 3);
        StartCoroutine(destroySelf());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnProjectile()
    {
        Instantiate(projectile, pumpkin.transform.position, Quaternion.identity);
    }



    public void FixedUpdate()
    {
        //gameObject.SetActive(true);
        //body.linearVelocity = (transform.position * projectileSpeed);


    }

    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
