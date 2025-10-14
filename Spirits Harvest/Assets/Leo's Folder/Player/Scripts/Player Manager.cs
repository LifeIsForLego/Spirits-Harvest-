using Unity.Multiplayer.Center.Common.Analytics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    public PlayerInputs inputs;
    public PlayerMovement move;
    public PlayerDictionary dict;

    //Tool Managers:
    public BroomManager broom;

    BlankState currentState;
    public IdleState idleState = new IdleState();
    public MoveState moveState = new MoveState();
    public InteractionState interactionState = new InteractionState();
    public ToolState toolState = new ToolState();

    BasicTool currentTool;
    BasicTool Tool1;
    BasicTool Tool2;
    BasicTool Tool3;
    public HarvestTool harvestTool = new HarvestTool();
    public PumpkinSeed pumpkinSeed = new PumpkinSeed();
    public BroomTool broomTool = new BroomTool();

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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerInputs.GetInstance().gameObject;
        inputs = player.GetComponent<PlayerInputs>();
        move = player.GetComponent<PlayerMovement>();
        dict = player.GetComponent<PlayerDictionary>();

        broom = player.GetComponent<BroomManager>();

        currentState = idleState;
        currentState.enterState(this);

        Tool1 = harvestTool;
        Tool2 = pumpkinSeed;
        Tool3 = broomTool;
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

        HandleTools();
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
}
