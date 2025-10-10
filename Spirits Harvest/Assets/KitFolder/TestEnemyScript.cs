using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TestEnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float enemyHealth = 5.0f;
    Rigidbody2D enemy;
    private bool moving = false;


    public void TakeDamage(float damage, float knockback)
    {
        Debug.Log("test");
        enemyHealth -= damage;
        float xVector = knockback;


        if (enemyHealth <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Enemy dead");
        }
    }

    public void EnemyMove()
    {
        float speed = 2.0f;
        if(Input.GetKeyDown(KeyCode.E))
        {
            moving = true;
            transform.Translate(Vector3.left * speed *  )
        }

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
