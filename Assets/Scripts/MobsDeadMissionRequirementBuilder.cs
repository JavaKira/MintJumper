using UnityEngine;

public class MobsDeadMissionRequirementBuilder : MissionRequirementBuilder
{
    [SerializeField] private Mob mobType;
    
    public override MissionRequirement Build()
    {
        return new MobsDeadMissionRequirement(title, mobType);
    }
}