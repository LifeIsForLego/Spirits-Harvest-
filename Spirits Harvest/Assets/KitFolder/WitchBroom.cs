using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WitchBroom : MonoBehaviour
{

    private float broomSpeed = 1.0f;

    private float broomDamage = 1.0f;

    public float broomCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // What is needed - Use the triangle as the broom and then have it so that when it touches something, it is able to knock it back and do 1hp.
    // Broom will need a collider, so will the enemy. When they touch, enemy knocked back. 


    // Update is called once per frame
    void Update()
    {
        if (broomCooldown <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                broomCooldown = broomSpeed;
            }
            else
            {
                broomCooldown -= Time.deltaTime;
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<TestEnemyScript>().TakeDamage(broomDamage);
                Debug.Log("Enemy hit");

            }
        }
        else
        {
            Debug.Log("No enemy");
        }
    }
}
