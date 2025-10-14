using UnityEngine;

public class HarvestTool : BasicTool
{
    public HarvestTool()
    {
        toolName = "Harvest";
    }

    public override void EquipTool(PlayerManager player)
    {
        Debug.Log("equipped the Harvester");
        player.canHarvest = true;
    }

    public override void UnequipTool(PlayerManager player)
    {
        player.canHarvest = false;
    }

    public override void ToolEffect(PlayerManager player)
    {
        
    }
}
