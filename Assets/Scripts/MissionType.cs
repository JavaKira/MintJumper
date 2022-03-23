using MissionRequirement;
using UnityEngine;

[CreateAssetMenu]
public class MissionType : ScriptableObject
{
    [SerializeField] 
    private string sceneName;
    //dirty hack, maybe ScriptableObject who given not implement IMissionRequirement
    [SerializeField]
    private ScriptableObject missionEndMainRequirement;

    public string SceneName => sceneName;
    public IMissionRequirement MissionEndMainRequirement => (IMissionRequirement) missionEndMainRequirement;
}