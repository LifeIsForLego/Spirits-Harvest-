using UnityEngine;

public class InteractionState : BlankState
{

    public override void enterState(PlayerManager player)
    {
        Debug.Log("InteractionState");

        player.move.noMove();
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

                string name = player.GetTempItemName();
                int value = player.GetTempItemValue();

                player.dict.AddItem(name,value);


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
