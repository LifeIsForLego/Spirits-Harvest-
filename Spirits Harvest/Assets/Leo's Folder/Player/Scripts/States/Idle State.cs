using UnityEngine;

public class IdleState : BlankState
{

    public override void enterState(PlayerManager player)
    {
        //Debug.Log("IdleState");
    }

    public override void exitState(PlayerManager player)
    {

    }

    public override void Move(PlayerManager player)
    {
        if(player != null)
        {
            player.move.Move();
        }
    }

    public override void Tool(PlayerManager player)
    {
        
    }

    public override void Interact(PlayerManager player)
    {
        
    }

    public override void Carving(PlayerManager player)
    {
        if(player.inputs.carveInput)
        {
            player.CarvingOn();
        }
    }

    public override void updateState(PlayerManager player)
    {
        Move(player);

        Carving(player);

        handleState(player);
    }

    public override void handleState(PlayerManager player)
    {
        if(player!=null)
        {
            if(player.GetCarving())
            {
                player.ChangeState(player.carvingState);
            }
            else if(player.interacting)
            {
                player.ChangeState(player.interactionState);
            }
            else if(player.getUsingTool())
            {
                player.ChangeState(player.toolState);
            }
            else if(player.inputs.Moving())
            {
                player.ChangeState(player.moveState);
            }
        }
    }
}
