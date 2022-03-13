using UnityEngine;

public class Mission : MonoBehaviour
{
    public static MissionType Preset;

    private void Awake()
    {
        Preset.MissionEndMainRequirement.DoneEvent.AddListener(End);
        Preset.MissionEndMainRequirement.AddDoneCheck();
    }

    public void End()
    {
        Game.Instance.Pause();
        FindObjectOfType<MissionEndPanel>(true).gameObject.SetActive(true);
    }
}