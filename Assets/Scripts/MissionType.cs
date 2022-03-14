public class MissionType
{
    private string _sceneName;
    public MissionRequirement.MissionRequirement MissionEndMainRequirement { get; }

    public MissionType(string sceneName, MissionRequirement.MissionRequirement missionEndMainRequirement)
    {
        _sceneName = sceneName;
        MissionEndMainRequirement = missionEndMainRequirement;
    }
}