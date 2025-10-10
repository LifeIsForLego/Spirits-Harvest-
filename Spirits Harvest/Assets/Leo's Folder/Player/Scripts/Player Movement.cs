using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;

    Rigidbody2D body;

    GameObject player;
    PlayerInputs inputs;
    PlayerManager manager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerInputs.GetInstance().gameObject;
        inputs = player.GetComponent<PlayerInputs>();
        manager = player.GetComponent<PlayerManager>();
        body = player.GetComponent<Rigidbody2D>();

        walkSpeed = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.Log(inputs.MoveInput);
    }

    public void Move()
    {
        body.linearVelocity = new Vector2(inputs.MoveInput.x * walkSpeed, inputs.MoveInput.y * walkSpeed);
    }

    public void noMove()
    {
        body.linearVelocity = new Vector2 (0, 0);
    }
}
