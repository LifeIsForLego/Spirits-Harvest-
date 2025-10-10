using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    public PlayerInputs inputs;
    public PlayerMovement move;

    BlankState currentState;
    public IdleState idleState = new IdleState();
    public MoveState moveState = new MoveState();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerInputs.GetInstance().gameObject;
        inputs = player.GetComponent<PlayerInputs>();
        move = player.GetComponent<PlayerMovement>();

        currentState = idleState;
        currentState.enterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.updateState(this);
    }

    public void ChangeState(BlankState state)
    {
        currentState.exitState(this);
        currentState = state;
        currentState.enterState(this);
    }
}
