public class MissionType
{
    private string _sceneName;
    public MissionRequirement MissionEndMainRequirement { get; }

    public MissionType(string sceneName, MissionRequirement missionEndMainRequirement)
    {
        _sceneName = sceneName;
        MissionEndMainRequirement = missionEndMainRequirement;
    }
}