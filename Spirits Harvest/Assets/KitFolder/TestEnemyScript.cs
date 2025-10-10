using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class TestEnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float enemyHealth = 5.0f;
    Rigidbody2D enemy;


    public void TakeDamage(float damage, float knockback)
    {
        
        enemyHealth -= damage;
        float xVector = knockback;
        transform.position = (Vector2.right * xVector).normalized;


        if (enemyHealth <= 0f )
        {
            Destroy(gameObject);
            Debug.Log("Enemy dead");
        }
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
