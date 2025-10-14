using UnityEngine;

public class ToolState : BlankState
{

    public override void enterState(PlayerManager player)
    {
        //Debug.Log("ToolState");

        player.move.noMove();
    }

    public override void exitState(PlayerManager player)
    {
        //Debug.Log("Exit");
    }

    public override void Move(PlayerManager player)
    {
       
    }

    public override void Tool(PlayerManager player)
    {
        player.toolTick();
    }

    public override void Interact(PlayerManager player)
    {

    }

    public override void Carving(PlayerManager player)
    {

    }

    public override void updateState(PlayerManager player)
    {
        Tool(player);

        handleState(player);
    }

    public override void handleState(PlayerManager player)
    {
        if (player != null)
        {
            if (!player.getUsingTool())
            {
                if (player.inputs.Moving())
                {
                    player.ChangeState(player.moveState);
                }
                else
                {
                    player.ChangeState(player.idleState);
                }
            }
        }
    }
}
