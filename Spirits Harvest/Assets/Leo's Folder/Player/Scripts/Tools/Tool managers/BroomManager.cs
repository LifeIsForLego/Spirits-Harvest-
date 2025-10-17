using UnityEngine;

public class BroomManager : MonoBehaviour
{
    bool toolEnabled;//if the broom is equipped then the manager is enabled and runs


    GameObject character;
    PlayerInputs inputs;
    PlayerManager manager;
    Rotate rotate;

    GameObject BroomHitBox = default;

    bool OffCooldown;
    bool inUse;
    bool Cooldown;

    [SerializeField]float UseDuration;
    float UseTimer;

    [SerializeField]float CooldownDuration;
    float CooldownTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        character = PlayerInputs.GetInstance().gameObject;
        inputs = character.GetComponent<PlayerInputs>();
        manager = character.GetComponent<PlayerManager>();
        rotate = character.GetComponent<Rotate>();

        BroomHitBox = transform.GetChild(0).gameObject;

        OffCooldown = true;
        inUse = false;
        Cooldown = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(toolEnabled && manager.playerMode)
        {
            
            if (inputs.useInput && OffCooldown)
            {
                manager.ToolInUse(UseDuration);
                StartTool();
            }

            if(inUse)
            {
                UseTick();
            }
            else if(Cooldown)
            {
                CooldownTick();
            }
        }
    }

    public void EnableTool()
    {
        toolEnabled = true;
    }
    public void DisableTool()
    {
        toolEnabled = false;
    }

    void EnableBroom()
    {
        //rotate code here
        rotate.Rotation(BroomHitBox);
        BroomHitBox.SetActive(true);
    }
    void DisableBroom()
    {
        BroomHitBox.SetActive(false);
    }

    void StartTool()
    {
        OffCooldown = false;
        inUse = true;
        UseTimer = UseDuration;
        EnableBroom();
    }

    
    void UseTick()
    {
        if(UseTimer <= 0)
        {
            UseStop();
        }
        else
        {
            UseTimer -= Time.deltaTime;
        }
    }
    void UseStop()
    {
        inUse = false;
        DisableBroom();
        StartCooldown();
    }

    void StartCooldown()
    {
        Cooldown = true;
        CooldownTimer = CooldownDuration;
    }
    void CooldownTick()
    {
        if(CooldownTimer <= 0)
        {
            StopCooldown();
        }
        else
        {
            CooldownTimer -= Time.deltaTime;
        }
    }
    void StopCooldown()
    {
        Cooldown = false;
        OffCooldown = true;
    }
}
