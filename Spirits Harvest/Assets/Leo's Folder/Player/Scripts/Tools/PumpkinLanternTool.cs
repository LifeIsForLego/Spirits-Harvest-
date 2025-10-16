using UnityEngine;

public class PumpkinLanternTool : BasicTool
{
    public PumpkinLanternTool()
    {
        toolName = "PumpkinLantern";
    }

    public override void EquipTool(PlayerManager player)
    {
        Debug.Log("equipped the PumpkinLantern");
        player.pumpLantern.EnableTool();
    }

    public override void UnequipTool(PlayerManager player)
    {
        player.pumpLantern.DisableTool();
    }

    public override void ToolEffect(PlayerManager player)
    {

    }
}
