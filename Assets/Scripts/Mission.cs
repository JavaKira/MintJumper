using System;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public static MissionType Preset;
    private int _stars;

    private void Start()
    {
        Preset.MissionEndMainRequirement.GetDoneEvent().AddListener(OnEndMainRequirementDone);
        Preset.MissionEndMainRequirement.AddDoneCheck();
        Preset.MissionRequirement2.GetDoneEvent().AddListener(OnRequirement2Done);
        Preset.MissionRequirement2.AddDoneCheck();
        Preset.MissionRequirement3.GetDoneEvent().AddListener(OnRequirement3Done);
        Preset.MissionRequirement3.AddDoneCheck();
    }

    private void OnEndMainRequirementDone()
    {
        End();
        Preset.MissionEndMainRequirement.RemoveDoneCheck();
        Preset.MissionEndMainRequirement.GetDoneEvent().RemoveListener(OnEndMainRequirementDone);
    }
    
    private void OnRequirement2Done()
    {
        AddStar();
        Preset.MissionRequirement2.RemoveDoneCheck();
        Preset.MissionRequirement2.GetDoneEvent().RemoveListener(OnRequirement2Done);
    }
    
    private void OnRequirement3Done()
    {
        AddStar();
        Preset.MissionRequirement3.RemoveDoneCheck();
        Preset.MissionRequirement3.GetDoneEvent().RemoveListener(OnRequirement3Done);
    }

    private void AddStar()
    {
        _stars += 1;
    }

    public void End()
    {
        _stars += 1;
        MissionStartPanel.LastPointData.Completed = true;
        MissionStartPanel.LastPointData.Stars = Math.Max(MissionStartPanel.LastPointData.Stars, _stars);
        Campaign.GetData().PutData(MissionStartPanel.LastPointData);
        FindObjectOfType<MissionEndPanel>(true).Open(MissionStartPanel.LastPointData);
        
        if (Preset.IssuedWeapon != null)
            Campaign.GetEquipmentData().UnlockWeapon(Preset.IssuedWeapon);
    }
}