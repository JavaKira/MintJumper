using UnityEngine;

public class MissionTypeBuilder : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private MissionRequirementBuilder missionEndMainRequirement;

    public string SceneName
    {
        get => sceneName;
        set => sceneName = value;
    }

    public void SetToPreset()
    {
        Mission.Preset = Build();
    }
    
    public MissionType Build()
    {
        return new MissionType(
            SceneName,
            missionEndMainRequirement.Build()
        );
    }
}