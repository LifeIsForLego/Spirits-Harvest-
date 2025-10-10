using UnityEngine;

public class InteractionState : BlankState
{

    public override void enterState(PlayerManager player)
    {
        Debug.Log("InteractionState");
    }

    public override void exitState(PlayerManager player)
    {

    }

    public override void Move(PlayerManager player)
    {

    }

    public override void useTools(PlayerManager player)
    {

    }

    public override void Interact(PlayerManager player)
    {
        if(player != null)
        {
            if(player.interactTimer <= 0)
            {
                player.InteractionEnd();
            }
            else
            {
                player.interactTimer -= Time.deltaTime;
            }
        }
    }

    public override void Carving(PlayerManager player)
    {

    }

    public override void updateState(PlayerManager player)
    {
        Interact(player);

        handleState(player);
    }

    public override void handleState(PlayerManager player)
    {
        if (player != null && !player.interacting)
        {
            if (player.inputs.Moving())
            {
                player.ChangeState(player.moveState);
            }
            else if (!player.inputs.Moving())
            {
                player.ChangeState(player.idleState);
            }
        }
    }
}
