using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TestEnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    //Can be changed.
    public float enemyHealth = 5.0f;
    //Rigidbody2D enemy;
    //private bool moving = false;


    public void TakeDamage(float damage, float knockback)
    {
        // Take away the damage from enemy health
        enemyHealth -= damage;
        // This will push back the enemy down and towards the right.
        transform.Translate(Vector3.right * knockback);
        transform.Translate(Vector3.down * (knockback * 0.1f));


        if (enemyHealth <= 0f)
        {
            // Destroy the enemy
            Destroy(gameObject);
            Debug.Log("Enemy dead");
        }
    }

    // A Test method for moving the enemy to test the knockback and also the damage
    public void EnemyMove()
    {
        float speed = 2.0f;
        bool moving = true;
        transform.Translate(Vector3.left * speed );

    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnemyMove();
        }
    }
}
