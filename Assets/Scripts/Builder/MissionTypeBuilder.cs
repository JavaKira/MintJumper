using UnityEngine;

public class MissionTypeBuilder : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private MissionRequirementBuilder missionEndMainRequirement;

    public void SetToPreset()
    {
        Mission.Preset = Build();
    }
    
    public MissionType Build()
    {
        return new MissionType(
            sceneName,
            missionEndMainRequirement.Build()
        );
    }
}