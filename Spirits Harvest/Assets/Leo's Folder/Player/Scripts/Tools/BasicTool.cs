using UnityEngine;

public abstract class BasicTool
{
    public string toolName;


    public abstract void EquipTool(PlayerManager player);

    public abstract void UnequipTool(PlayerManager player);


}
