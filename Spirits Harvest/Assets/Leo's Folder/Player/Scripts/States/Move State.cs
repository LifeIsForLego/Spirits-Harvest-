using UnityEngine;

public class MoveState : BlankState
{

    public override void enterState(PlayerManager player)
    {
        //Debug.Log("MoveState");
    }

    public override void exitState(PlayerManager player)
    {

    }

    public override void Move(PlayerManager player)
    {
        if (player != null)
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

    }

    public override void updateState(PlayerManager player)
    {
        Move(player);

        handleState(player);
    }

    public override void handleState(PlayerManager player)
    {
        if (player != null)
        {
            if (player.interacting)
            {
                player.ChangeState(player.interactionState);
            }
            else if (player.getUsingTool())
            {
                player.ChangeState(player.toolState);
            }
            else if (!player.inputs.Moving())
            {
                player.ChangeState(player.idleState);
            }
        }
    }
}
