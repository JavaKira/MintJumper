using MissionRequirement;
using UnityEngine;

[CreateAssetMenu]
public class MissionType : ScriptableObject
{
    [SerializeField] private string sceneName;

    //dirty hack, maybe ScriptableObject who given not implement IMissionRequirement
    [SerializeField] private ScriptableObject missionEndMainRequirement;

    [SerializeField] private ScriptableObject missionRequirement2;

    [SerializeField] private ScriptableObject missionRequirement3;

    public string SceneName => sceneName;
    public IMissionRequirement MissionEndMainRequirement => (IMissionRequirement) missionEndMainRequirement;
    public IMissionRequirement MissionRequirement2 => (IMissionRequirement) missionRequirement2;
    public IMissionRequirement MissionRequirement3 => (IMissionRequirement) missionRequirement3;
}