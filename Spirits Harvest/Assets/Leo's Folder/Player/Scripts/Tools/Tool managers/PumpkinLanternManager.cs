using UnityEngine;

public class PumpkinLanternManager : MonoBehaviour
{
    bool toolEnabled;//if the tool is equipped then the manager is enabled and runs


    GameObject character;
    PlayerInputs inputs;
    PlayerManager manager;

    float Duration;
    float Timer;
    bool canPlace;
    bool OnLantern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        character = PlayerInputs.GetInstance().gameObject;
        inputs = character.GetComponent<PlayerInputs>();
        manager = character.GetComponent<PlayerManager>();

        Duration = 0.5f;
        Timer = 0;
        canPlace = true;
        OnLantern = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toolEnabled && manager.playerMode)
        {
            if (inputs.useInput && canPlace && !OnLantern)
            {
                manager.placePumpkinLantern();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Lantern"))
        {
            OnLantern = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Lantern"))
        {
            OnLantern = false;
        }
    }

    void StartTimer()
    {
        Timer = Duration;
        canPlace = false;
    }
    void TimerTick()
    {
        if(Timer <= 0)
        {
            EndTimer();
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }
    void EndTimer()
    {
        canPlace = true;
    }

    public void EnableTool()
    {
        toolEnabled = true;
    }
    public void DisableTool()
    {
        toolEnabled = false;
    }
}
