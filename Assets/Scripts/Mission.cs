using UnityEngine;

public class Mission : MonoBehaviour
{
    public static MissionType Preset;

    private void Awake()
    {
        Preset.MissionEndMainRequirement.GetDoneEvent().AddListener(End);
        Preset.MissionEndMainRequirement.AddDoneCheck();
    }

    public void End()
    {
        Game.Instance.Pause();
        MissionStartPanel.LastPointData.Completed = true;
        Campaign.GetData().PutData(MissionStartPanel.LastPointData);
        FindObjectOfType<MissionEndPanel>(true).Open(MissionStartPanel.LastPointData);
    }
}