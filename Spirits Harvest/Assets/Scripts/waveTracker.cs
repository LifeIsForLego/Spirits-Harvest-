using UnityEngine;
using UnityEngine.UI;

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
    public Slider waveTimerSlider;

    private void Start()
    {
        waveBreakTimer = waveBreak;
        waveTimerSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(canStartNextWave == false && waveEnded == true)
        {
            waveTimerSlider.gameObject.SetActive(true);
            waveBreakTimer -= Time.deltaTime;
            waveTimerSlider.value = waveBreakTimer;
        }

        isWaveOver();

        if ((Input.GetKeyDown(KeyCode.Space) && waveEnded == true) || waveBreakTimer <= 0)
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
        if (waveNum <= 5)
        {
            enemyPoolTotal = enemyPoolTotal + 2;
            spawnCooldown = spawnCooldown - 0.2f;
            enemyPool = enemyPoolTotal;
        }

        else if (waveNum <= 10)
        {
            enemyPoolTotal = enemyPoolTotal + 5;
            enemyPool = enemyPoolTotal;
        }

        else if (waveNum <= 15)
        {
            spawnCooldown = 0.75f;
            enemyPoolTotal = 50;
        }

        else if (waveNum > 15)
            Debug.Log("YouWin");
    }

    void startNextWave()
    {
        waveStart = true; canStartNextWave = false; waveEnded = false;
        waveNum++;
        waveHandler();
        waveBreakTimer = waveBreak;
        waveTimerSlider.gameObject.SetActive(false);
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
