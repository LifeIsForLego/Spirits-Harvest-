using UnityEngine;

public class BroomHit : MonoBehaviour
{
    //private float broomSpeed = 1.0f;

    private float broomDamage = 1.0f;

    //Used for affecting how far back enemies will move
    //private float broomKnockback = 2.0f;

    //Stop spamming of it? Not sure if this works
    //public float broomCooldown;

    //public bool isAttacking = false;

    //public int attack = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // What is needed - Use the triangle as the broom and then have it so that when it touches something, it is able to knock it back and do 1hp.
    // Broom will need a collider, so will the enemy. When they touch, enemy knocked back. 


    // Update is called once per frame


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    //Debug.Log("Attacking");
        //    isAttacking = true;
        //}

        //if (broomCooldown > 0f)
        //{
        //    broomCooldown -= Time.deltaTime;
        //}
        // else if (broomCooldown <= 0f)
        //{
        //     broomCooldown = broomSpeed;
        //     broomCooldown -= Time.deltaTime;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            // Will trigger the TakeDamage script
            //
            //collision.GetComponent<TestEnemyScript>().TakeDamage(broomDamage, broomKnockback);
            
            Debug.Log("Enemy hit");

            //add in damage code on enemy
            //add in knockback effect on enemy
        }



    }
}
