using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private static PlayerInputs instance;
    public static PlayerInputs GetInstance() { return instance; }

    [SerializeField] InputActionAsset playerinputs;

    [SerializeField] string MovementMapName = "PlayerMovement";

    [SerializeField] string InteractMapName = "PlayerInteractions";

    [SerializeField] string ToolMapName = "PlayerTools";


    [SerializeField] string move = "Move";

    [SerializeField] string interact = "Interact";

    [SerializeField] string tool1 = "Tool1";
    [SerializeField] string tool2 = "Tool2";
    [SerializeField] string tool3 = "Tool3";


    InputAction moveAction;
    InputAction interactAction;
    InputAction tool1Action;
    InputAction tool2Action;
    InputAction tool3Action;

    public Vector2 MoveInput;
    public bool InteractInput;
    public bool tool1Input;
    public bool tool2Input;
    public bool tool3Input;


    string facing;

    private void Awake()
    {
        instance = this;

        moveAction = playerinputs.FindActionMap(MovementMapName).FindAction(move);
        interactAction = playerinputs.FindActionMap(InteractMapName).FindAction(interact);
        tool1Action = playerinputs.FindActionMap(ToolMapName).FindAction(tool1);
        tool2Action = playerinputs.FindActionMap(ToolMapName).FindAction(tool2);
        tool3Action = playerinputs. FindActionMap(ToolMapName).FindAction(tool3);

        RegisterInputs();
    }

    void RegisterInputs()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        interactAction.performed += context => InteractInput = true;
        interactAction.canceled += context => InteractInput = false;

        tool1Action.performed += context => tool1Input = true;
        tool1Action.canceled += context => tool1Input = false;

        tool2Action.performed += context => tool2Input = true;
        tool2Action.canceled += context => tool2Input = false;

        tool3Action.performed += context => tool3Input = true;
        tool3Action.canceled += context => tool3Input = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        interactAction.Enable();
        tool1Action.Enable();
        tool2Action.Enable();
        tool3Action.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        interactAction.Disable();
        tool1Action.Disable();
        tool2Action.Disable();
        tool3Action.Disable();
    }






    void Update()
    {
        currentDirection();
    }

    public bool Moving()
    {
        if(Mathf.Abs(MoveInput.x) > 0 || Mathf.Abs(MoveInput.y) > 0)
        {
            return true;
        }
        return false;
    }

    void currentDirection()
    {
        //N y = 1 x = 0
        if (MoveInput.x == 0 && MoveInput.y > 0)
        {
            facing = "North";
        }
        //NE y = 1 x = 1
        else if (MoveInput.x > 0 && MoveInput.y > 0)
        {
            facing = "NorthEast";
        }
        //E y = 0 x = 1
        else if (MoveInput.x > 0 && MoveInput.y == 0)
        {
            facing = "East";
        }
        //SE y = -1 x = 1
        else if (MoveInput.x > 0 && MoveInput.y < 0)
        {
            facing = "SouthEast";
        }
        //S y = -1 x = 0
        else if (MoveInput.x == 0 && MoveInput.y < 0)
        {
            facing = "South";
        }
        //SW y = -1 x = -1
        else if (MoveInput.x < 0 && MoveInput.y < 0)
        {
            facing = "SouthWest";
        }
        //W y = 0 x = -1
        else if (MoveInput.x < 0 && MoveInput.y == 0)
        {
            facing = "West";
        }
        //NW y = 1 x = -1
        else if (MoveInput.x < 0 && MoveInput.y > 0)
        {
            facing = "NorthWest";
        }
    }

    public string GetDirection()
    {
        return facing;
    }

}
