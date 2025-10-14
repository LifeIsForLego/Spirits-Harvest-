using UnityEngine;

public class HarvestTool : BasicTool
{
    public HarvestTool()
    {
        toolName = "Harvest";
    }

    public override void EquipTool(PlayerManager player)
    {
        Debug.Log("equiped the Harvester");
        player.canHarvest = true;
    }

    public override void UnequipTool(PlayerManager player)
    {
        player.canHarvest = false;
    }
}
