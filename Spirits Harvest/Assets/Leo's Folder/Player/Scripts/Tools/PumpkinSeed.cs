using UnityEngine;

public class PumpkinSeed : BasicTool
{
    public PumpkinSeed()
    {
        toolName = "PumpkinSeed";
    }

    public override void EquipTool(PlayerManager player)
    {
        Debug.Log("equiped the PumpkinSeed");
        player.canPlant = true;
        player.SeedName = toolName;
    }

    public override void UnequipTool(PlayerManager player)
    {
        player.canPlant = false;
    }
}
