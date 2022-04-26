using UnityEngine;
using UnityEngine.Localization.Components;

public class MissionRequirementsPanel : MonoBehaviour
{
    [SerializeField] private GameObject missionMainRequirementsPanel;
    [SerializeField] private GameObject missionRequirements2Panel;
    [SerializeField] private GameObject missionRequirements3Panel;

    private void Start()
    {
        missionMainRequirementsPanel.GetComponentInChildren<LocalizeStringEvent>().StringReference =
            Mission.Preset.MissionEndMainRequirement.GetStringReference();
        
        missionRequirements2Panel.GetComponentInChildren<LocalizeStringEvent>().StringReference =
            Mission.Preset.MissionRequirement2.GetStringReference();

        missionRequirements3Panel.GetComponentInChildren<LocalizeStringEvent>().StringReference =
            Mission.Preset.MissionRequirement3.GetStringReference();
    }

    private void OnEnable()
    {
        Mission.Preset.MissionEndMainRequirement.GetDoneEvent().AddListener(OnCompleteMissionMainRequirement);
        Mission.Preset.MissionRequirement2.GetDoneEvent().AddListener(OnCompleteMissionRequirement2);
        Mission.Preset.MissionRequirement3.GetDoneEvent().AddListener(OnCompleteMissionRequirement3);
    }

    private void OnCompleteMissionMainRequirement()
    {
        missionMainRequirementsPanel.GetComponentInChildren<Star>().UpdateState(true);
    }
    
    private void OnCompleteMissionRequirement2()
    {
        missionRequirements2Panel.GetComponentInChildren<Star>().UpdateState(true);
    }
    
    private void OnCompleteMissionRequirement3()
    {
        missionRequirements3Panel.GetComponentInChildren<Star>().UpdateState(true);
    }

    private void OnDisable()
    {
        Mission.Preset.MissionEndMainRequirement.GetDoneEvent().RemoveListener(OnCompleteMissionMainRequirement);
        Mission.Preset.MissionEndMainRequirement.GetDoneEvent().RemoveListener(OnCompleteMissionRequirement2);
        Mission.Preset.MissionEndMainRequirement.GetDoneEvent().RemoveListener(OnCompleteMissionRequirement3);
    }
}