using UnityEngine;

public class IdleState : BlankState
{

    public override void enterState(PlayerManager player)
    {
        Debug.Log("IdleState");
    }

    public override void exitState(PlayerManager player)
    {

    }

    public override void Move(PlayerManager player)
    {
        if(player == null)
        {

        }
    }

    public override void useTools(PlayerManager player)
    {
        
    }

    public override void Interact(PlayerManager player)
    {
        
    }

    public override void Carving(PlayerManager player)
    {
        
    }

    public override void updateState(PlayerManager player)
    {
        Move(player);

        handleState(player);
    }

    public override void handleState(PlayerManager player)
    {
        
    }
}
