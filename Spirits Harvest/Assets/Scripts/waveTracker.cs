using UnityEngine;

public class waveTracker : MonoBehaviour
{
    [SerializeField] bool waveStart = false;
    [SerializeField] int waveNum = 0;
    [SerializeField] bool canStartNextWave = true;
    [SerializeField] bool waveEnded = false;

    [SerializeField] float waveBreakTimer = 0f;
    [SerializeField] float waveBreak = 5f;

    [SerializeField] int enemyPool;
    public int enemyPoolTotal = 10;
    public GameObject enemy;
    public GameObject[] enemyArray;

    public float spawnCooldown = 3f;
    float spawnTimer;

    private void Start()
    {
        waveBreakTimer = waveBreak;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(canStartNextWave == false && waveEnded == true)
        {
            waveBreakTimer -= Time.deltaTime;
        }

        isWaveOver();

        if (Input.GetKeyDown(KeyCode.Space) || waveBreakTimer <= 0)
        {
            startNextWave();
        }


        while (waveStart && enemyPool > 0 && spawnTimer <= 0f)
        {
            GameObject.Instantiate(enemy, this.gameObject.transform.position, Quaternion.identity);
            enemyPool--;
            spawnTimer = spawnCooldown;
        }
    }

    void waveHandler()
    {
        if(waveNum <= 5)
        {
            enemyPoolTotal = enemyPoolTotal + 2;
            enemyPool = enemyPoolTotal;
        }

        else if(waveNum <= 10)
        {
            enemyPoolTotal = enemyPoolTotal + 5;
            enemyPool = enemyPoolTotal;
        }

        else if (waveNum <= 15)
        {
            spawnCooldown = 0.5f;
        }
    }

    void startNextWave()
    {
        waveStart = true; canStartNextWave = false; waveEnded = false;
        waveNum++;
        waveHandler();
        waveBreakTimer = waveBreak;
    }

    void isWaveOver()
    {
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyPool <= 0 && enemyArray.Length == 0)
        {
            waveEnded = true;
        }
    }
}
