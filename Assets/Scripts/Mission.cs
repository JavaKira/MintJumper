using System;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public static MissionType Preset;
    private int _stars;

    private void Start()
    {
        Game.Instance.Stats.Changed.AddListener(() =>
        {
            Debug.Log(Game.Instance.Stats.GetMobsLive("Beetle"));
        });
        
        Preset.MissionEndMainRequirement.GetDoneEvent().AddListener(End);
        Preset.MissionEndMainRequirement.AddDoneCheck();
        Preset.MissionRequirement2.GetDoneEvent().AddListener(AddStar);
        Preset.MissionRequirement2.AddDoneCheck();
        Preset.MissionRequirement3.GetDoneEvent().AddListener(AddStar);
        Preset.MissionRequirement3.AddDoneCheck();
    }

    private void AddStar()
    {
        _stars += 1;
    }

    public void End()
    {
        _stars += 1;
        Game.Instance.Pause();
        MissionStartPanel.LastPointData.Completed = true;
        MissionStartPanel.LastPointData.Stars = Math.Max(MissionStartPanel.LastPointData.Stars, _stars);
        Campaign.GetData().PutData(MissionStartPanel.LastPointData);
        FindObjectOfType<MissionEndPanel>(true).Open(MissionStartPanel.LastPointData);
    }
}