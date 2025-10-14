using UnityEngine;

public class Empty : BasicTool
{
    public Empty()
    {
        toolName = "Empty";
    }

    public override void EquipTool(PlayerManager player)
    {
        Debug.Log("equipped nothing");
    }

    public override void UnequipTool(PlayerManager player)
    {

    }

    public override void ToolEffect(PlayerManager player)
    {

    }
}
