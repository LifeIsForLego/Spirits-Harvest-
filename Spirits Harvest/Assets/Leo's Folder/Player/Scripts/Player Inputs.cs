using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private static PlayerInputs instance;
    public static PlayerInputs GetInstance() { return instance; }

    [SerializeField] InputActionAsset playerinputs;

    [SerializeField] string actionMapName = "PlayerMovement";

    [SerializeField] string move = "Move";

    InputAction moveAction;

    public Vector2 MoveInput { get; private set; }

    private void Awake()
    {
        instance = this;

        moveAction = playerinputs.FindActionMap(actionMapName).FindAction(move);//

        RegisterInputs();
    }

    void RegisterInputs()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();//
    }

    public bool Moving()
    {
        if(Mathf.Abs(MoveInput.x) > 0 || Mathf.Abs(MoveInput.y) > 0)
        {
            return true;
        }
        return false;
    }    

}
