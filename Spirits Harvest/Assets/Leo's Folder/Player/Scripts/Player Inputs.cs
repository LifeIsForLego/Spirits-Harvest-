using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private static PlayerInputs instance;
    public static PlayerInputs GetInstance() { return instance; }

    [SerializeField] InputActionAsset playerinputs;

    [SerializeField] string MovementMapName = "PlayerMovement";

    [SerializeField] string InteractMapName = "PlayerInteractions";

    [SerializeField] string move = "Move";

    [SerializeField] string interact = "Interact";

    InputAction moveAction;
    InputAction interactAction;

    public Vector2 MoveInput;
    public bool InteractInput;


    string facing;

    private void Awake()
    {
        instance = this;

        moveAction = playerinputs.FindActionMap(MovementMapName).FindAction(move);
        interactAction = playerinputs.FindActionMap(InteractMapName).FindAction(interact);

        RegisterInputs();
    }

    void RegisterInputs()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        interactAction.performed += context => InteractInput = true;
        interactAction.canceled += context => InteractInput = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        interactAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        interactAction.Disable();
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
