using UnityEngine;

public class TestEnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float enemyHealth = 5.0f;


    public void TakeDamage(float broomDamage)
    {
        enemyHealth -= broomDamage;

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
