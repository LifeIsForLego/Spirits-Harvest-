using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WitchBroom : MonoBehaviour
{
    private InputActionAsset broomControls;
    private string actionMapName = "Broom";
    private string move = "Move";
    private string attack = "Attack";
    //protected float speed = 1.0f;

    private InputAction moveAction;
    private InputAction attackAction;

    public Vector2 MoveInput { get; private set; }
    public bool AttackTriggered { get; private set; }







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // What is needed - Use the triangle as the broom and then have it so that when it touches something, it is able to knock it back and do 1hp.
    // Broom will need a collider, so will the enemy. When they touch, enemy knocked back. 

    public void BroomAttack()
    {


    }

    public void BroomMove()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
