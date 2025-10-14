using UnityEngine;

public class BroomTool : BasicTool
{
    public BroomTool()
    {
        toolName = "Broom";
    }

    public override void EquipTool(PlayerManager player)
    {
        Debug.Log("equipped the Broom");
        player.broom.EnableTool();
    }

    public override void UnequipTool(PlayerManager player)
    {
        player.broom.DisableTool();
    }

    public override void ToolEffect(PlayerManager player)
    {

    }
}
