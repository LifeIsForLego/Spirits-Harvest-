using UnityEngine;

public class CarvingState : BlankState
{

    public override void enterState(PlayerManager player)
    {
        Debug.Log("CarvingState");

        player.move.noMove();

        player.playerMode = false;
        player.cams.CarvingOn();
        player.UIc.CarveModeOn();
        player.draw.ENABLEDON();
    }

    public override void exitState(PlayerManager player)
    {
        Debug.Log("left CarvingState");

        player.playerMode=true;
        player.cams.CarvingOff();
        player.UIc.CarveModeOff();
        player.draw.ENABLEDOFF();
    }

    public override void Move(PlayerManager player)
    {

    }

    public override void Tool(PlayerManager player)
    {

    }

    public override void Interact(PlayerManager player)
    {

    }

    public override void Carving(PlayerManager player)
    {
        if(player.draw.finishedButtonPressed)
        {
            player.CarvingOff();
        }
    }

    public override void updateState(PlayerManager player)
    {
        Carving(player);

        handleState(player);
    }

    public override void handleState(PlayerManager player)
    {
        if (player != null)
        {
            if (!player.GetCarving())
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
