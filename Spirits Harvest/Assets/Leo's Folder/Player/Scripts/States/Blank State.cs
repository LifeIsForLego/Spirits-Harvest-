using UnityEngine;

public abstract class BlankState
{
    public abstract void enterState(PlayerManager player);

    public abstract void exitState(PlayerManager player);

    public abstract void updateState(PlayerManager player);

    public abstract void handleState(PlayerManager player);

    public abstract void Move(PlayerManager player);

    public abstract void useTools(PlayerManager player);

    public abstract void Interact(PlayerManager player);

    public abstract void Carving(PlayerManager player);
}
