using Unity.Multiplayer.Center.Common.Analytics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    public PlayerInputs inputs;
    public PlayerMovement move;
    public PlayerDictionary dict;
    public Animator animator;

    public CameraManager cams;
    public UICarve UIc;
    public Draw draw;

    //Tool Managers:
    public BroomManager broom;
    public PumpkinLanternManager pumpLantern;

    BlankState currentState;
    public IdleState idleState = new IdleState();
    public MoveState moveState = new MoveState();
    public InteractionState interactionState = new InteractionState();
    public ToolState toolState = new ToolState();
    public CarvingState carvingState = new CarvingState();

    BasicTool currentTool;
    BasicTool Tool1;
    BasicTool Tool2;
    BasicTool Tool3;
    BasicTool Tool4;
    public HarvestTool harvestTool = new HarvestTool();
    public PumpkinSeed pumpkinSeed = new PumpkinSeed();
    public BroomTool broomTool = new BroomTool();
    public PumpkinLanternTool planternTool = new PumpkinLanternTool();

    public bool playerMode;

    public bool interacting;
    public float interactTick;
    public float interactTimer;

    public bool canHarvest;
    public bool canPlant;
    public string SeedName;

    string tempItemName;
    int tempItemValue;

    bool usingTool;
    float toolTimer;

    bool Carving;

    //[SerializeField] GameObject pumpkLantern;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMode = true;

        player = PlayerInputs.GetInstance().gameObject;
        inputs = player.GetComponent<PlayerInputs>();
        move = player.GetComponent<PlayerMovement>();
        dict = player.GetComponent<PlayerDictionary>();
        animator = GetComponent<Animator>();

        broom = player.GetComponent<BroomManager>();
        pumpLantern = player.GetComponent<PumpkinLanternManager>();

        currentState = idleState;
        currentState.enterState(this);

        Tool1 = harvestTool;
        Tool2 = pumpkinSeed;
        Tool3 = broomTool;
        Tool4 = planternTool;
        currentTool = Tool1;

        interacting = false;
        interactTick = 0.25f;
        interactTimer = 0;

        canHarvest = false;
        canPlant = false;
        SeedName = "null";

        Debug.Log(currentTool);
        currentTool.EquipTool(this);

        tempItemName = "null";
        tempItemValue = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.updateState(this);

        if (playerMode)
        {
            HandleTools();
        }
    }

    public void ChangeState(BlankState state)
    {
        currentState.exitState(this);
        currentState = state;
        currentState.enterState(this);
    }
    public void SwapTool(BasicTool tool)
    {
        currentTool.UnequipTool(this);
        currentTool = tool;
        currentTool.EquipTool(this);
    }

    void HandleTools()
    {
        if(inputs.tool1Input)
        {
            SwapTool(Tool1);
        }
        else if(inputs.tool2Input)
        {
            SwapTool(Tool2);
        }
        else if (inputs.tool3Input)
        {
            SwapTool(Tool3);
        }
        else if(inputs.tool4Input)
        {
            SwapTool(Tool4);
        }
    }


    public void InteractionStart(string itemName, int itemValue)
    {
        interacting = true;

        interactTimer = interactTick;

        tempItemName = itemName;
        tempItemValue = itemValue;
    }

    public void InteractionEnd()
    {
        interacting = false;
    }

    public float GetInteractTick()
    {
        return interactTick;
    }

    public string GetTempItemName()
    {
        return tempItemName;
    }
    public int GetTempItemValue()
    {
        return tempItemValue;
    }
    public void resetTempvals()
    {
        tempItemName="null";
        tempItemValue=0;
    }


    public void ToolInUse(float useDuration)
    {
        usingTool = true;
        toolTimer = useDuration;
    }

    public bool getUsingTool()
    {
        return usingTool;
    }

    public void toolTick()
    {
        if(toolTimer<=0)
        {
            usingTool = false;
        }
        else
        {
            toolTimer -= Time.deltaTime;
        }
    }

    public void CarvingOn()
    {
        Carving = true;
    }
    public void CarvingOff()
    {
        Carving = false;
    }
    public bool GetCarving()
    {
        return Carving;
    }

    public bool checkPumpkinMaterials()
    {
        //make temp vars and check theres at least 1 pumpkin and 1 candle
        int tempPum = dict.GetItem("Pumpkin");
        int tempCand = dict.GetItem("Candle");

        if(tempPum > 0 && tempCand > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void carvePumpkinLantern()
    {
        //remove 1 pumpkin and 1 candle and add 1 jackolantern(pumpkin)
        if(checkPumpkinMaterials())
        {
            dict.RemoveItem("Pumpkin", 1);
            dict.RemoveItem("Candle", 1);
            dict.AddItem("PumpkinLantern", 1);
        }
    }
    public void placePumpkinLantern()
    {
        //remove 1 pumpkin lantern if possible and if so, place a pumpkinlantern object
        int tempLantern = dict.GetItem("PumpkinLantern");
        if(tempLantern > 0)
        {
            dict.RemoveItem("PumpkinLantern", 1);
            Debug.Log("LanternPlaced");
        }
        else
        {
            Debug.Log("no Lantern");
        }
    }
}
