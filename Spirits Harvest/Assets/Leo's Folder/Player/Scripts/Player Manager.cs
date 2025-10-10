using Unity.Multiplayer.Center.Common.Analytics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    public PlayerInputs inputs;
    public PlayerMovement move;

    BlankState currentState;
    public IdleState idleState = new IdleState();
    public MoveState moveState = new MoveState();
    public InteractionState interactionState = new InteractionState();

    public bool interacting;
    public float interactTick;
    public float interactTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerInputs.GetInstance().gameObject;
        inputs = player.GetComponent<PlayerInputs>();
        move = player.GetComponent<PlayerMovement>();

        currentState = idleState;
        currentState.enterState(this);

        interacting = false;
        interactTick = 0.25f;
        interactTimer = 0;
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

    public void InteractionStart()
    {
        interacting = true;

        interactTimer = interactTick;
    }

    public void InteractionEnd()
    {
        interacting = false;
    }
}
